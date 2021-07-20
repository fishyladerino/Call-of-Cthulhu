using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        #region Singleton

        public static PlayerController instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        #region Components
        public CharacterController controller;
        public Animator anim;
        public GameObject weapon;
        #endregion

        #region Movement
        public Vector3 movement;
        public float speed = 1f;
        public float directionX;
        public float directionZ;
        #endregion

        #region Shooting
        //migrate to weapon script for easier scaling
        public float startTimeBtwShots;
        public float timeBtwShots;
        public GameObject projectile;
        public GameObject shotPoint;
        public string weaponType;
        Weapon weaponScript;
        #endregion

        #region Bools
        public bool isGliding;
        public bool isBlocking;
        #endregion

        #region Gravity
        public float gravity = -10f;
        public Vector3 velocity;
        #endregion

        #region Grounded?
        public Transform groundCheck;
        public float groundDistance;
        public LayerMask groundMask;
        public static bool isGrounded;
        #endregion

        #region States
        EmptyState emptyState = new EmptyState();
        PlayerIdle playerIdle = new PlayerIdle();
        PlayerWalking playerWalking = new PlayerWalking();
        PlayerRunning playerRunning = new PlayerRunning();
        PlayerJump playerJump = new PlayerJump();
        PlayerGlide playerGlide = new PlayerGlide();
        PlayerAttack playerAttack = new PlayerAttack();
        PlayerBlock playerBlock = new PlayerBlock();
        IPlayerStates currentMovementState;
        IPlayerStates currentAerialMovementState;
        IPlayerStates currentCombatState;
        #endregion

        void Start()
        {
            //Assign vars
            OnWeaponSwitch();
            controller = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;

            //Assign default states
            currentMovementState = playerIdle;
            currentAerialMovementState = emptyState;
            currentCombatState = emptyState;
        }

        void Update()
        {
            GroundedCheck();
            ResetVelocity();
            Gravity();
            Movement();
            currentMovementState.OnStateExecution();
            currentAerialMovementState.OnStateExecution();
            currentCombatState.OnStateExecution();

            if (isGrounded) Debug.Log("grounded");

            //Handles movement states
            if (directionX == 0 && directionZ == 0) ChangeMovementState(playerIdle);
            else if (directionX != 0 || directionZ != 0 && !Input.GetKey(KeyCode.LeftShift)) ChangeMovementState(playerWalking);
            else if (directionX != 0 || directionZ != 0 && Input.GetKey(KeyCode.LeftShift)) ChangeMovementState(playerRunning);

            //Handles air movement states separately to allow for in air movement
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) ChangeAerialMovementState(playerJump);
            else if (Input.GetKey(KeyCode.Space)) ChangeAerialMovementState(playerGlide);
            else ChangeAerialMovementState(emptyState);

            //Handles combat separately to allow for aerial combat
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChangeCombatState(playerAttack);
                    timeBtwShots = startTimeBtwShots;
                }
                else if (Input.GetMouseButton(1)) ChangeCombatState(playerBlock);
                else ChangeCombatState(emptyState);
            }
            else timeBtwShots -= Time.deltaTime;
        }

        private void ChangeMovementState(IPlayerStates newState)
        {
            currentMovementState.OnStateExit();
            newState.OnStateEnter();
            currentMovementState = newState;
        }

        private void ChangeCombatState(IPlayerStates newState)
        {
            currentCombatState.OnStateExit();
            newState.OnStateEnter();
            currentCombatState = newState;
        }

        private void ChangeAerialMovementState(IPlayerStates newState)
        {
            currentAerialMovementState.OnStateExit();
            newState.OnStateEnter();
            currentAerialMovementState = newState;
        }

        private void ResetVelocity()
        {
            if (isGrounded && velocity.y < 0) velocity.y = -2f;
        }

        private void Gravity()
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private void Movement()
        {
            directionX = Input.GetAxisRaw("Horizontal");
            directionZ = Input.GetAxisRaw("Vertical");
            movement = transform.right * directionX + transform.forward * directionZ;
            controller.Move(movement * speed * Time.deltaTime);
        }

        //Creates sphere under player and checks if it is in contact with ground
        private void GroundedCheck()
        {          
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        }

        //Used in event to return to base animation
        public void ResetAttack()
        {          
            anim.SetBool("attacking", false);
        }

        //finds new weapon anim when weapon switches
        public void OnWeaponSwitch()
        {
            weapon = GameObject.FindGameObjectWithTag("Weapon");
            anim = weapon.GetComponent<Animator>();
            weaponScript = weapon.GetComponent<Weapon>();
            projectile = weaponScript.weaponProjectile;
            shotPoint = weaponScript.shotPoint;
            startTimeBtwShots = weaponScript.weaponCooldown;
            weaponType = weaponScript.weaponType;
        }
    }
}