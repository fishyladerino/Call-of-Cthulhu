using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemys.EnemyScripts
{
    public class EnemyData : MonoBehaviour
    {
        #region Components
        public GameObject enemy;
        public EnemyData enemyData;      
        public NavMeshAgent agent;
        public CharacterController controller;
        public Animator anim;
        #endregion

        #region Player 
        public LayerMask playerMask;
        #endregion

        #region EnemyInfo
        public float speed;
        public float health;
        public string enemyType;
        #endregion

        #region Shooting
        public GameObject shotPoint;
        public GameObject projectile;
        public float startTimeBtwShots;
        public float timeBtwShots;
        #endregion

        #region StateControl
        public float sightDistance;
        public float attackRange;
        public bool inSightRange;
        public bool inAttackRange;
        #endregion

        void Start()
        {
            enemy = gameObject;
            enemyData = GetComponent<EnemyData>();
            anim = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
            agent = GetComponent<NavMeshAgent>();
        }
    }
}
