using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    public class WeaponAnimator : MonoBehaviour
    {
        #region Components
        GameObject player;
        GameObject weaponOrigin;
        public static Animator anim;
        #endregion

        #region Audio
        public AudioSource audio;
        public AudioClip run;
        public AudioClip attack;
        public AudioClip jump;
        public AudioSource glide;
        #endregion

        void Start()
        {
            anim = GetComponent<Animator>();
            player = GameObject.Find("Player");
            weaponOrigin = GameObject.Find("WeaponSpawn");
        }

        private void Update()
        {
            Glide();

            //if (weaponOrigin.GetComponent<WeaponSwapping>().weaponSwitched) anim.SetBool("pulledout", true);
            //else anim.SetBool("pulledout", false);
        }

        private void ResetAttack()
        {
            PlayerController.instance.ResetAttack();
        }

        private void Walk()
        {
            //plays footstep noises if player on ground
            if (PlayerController.isGrounded) audio.PlayOneShot(run);
        }

        private void Attack()
        {
            audio.PlayOneShot(attack);
        }

        internal void Jump()
        {
            //audio.PlayOneShot(jump);
        }

        private void Glide()
        {
            glide.enabled = PlayerController.instance.isGliding;
        }

        /**private void SwapWeapons()
        {
            weaponOrigin.GetComponent<WeaponSwapping>().SelectWeapon();
        }*/
    }
}