using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemys.EnemyScripts
{
    public class EnemyChase : IEnemyStates
    {
        GameObject enemy;
        EnemyData enemyData;
        string enemyType;
        NavMeshAgent agent;
        Animator anim;
        float speed;
        Vector3 playerPos;
        Quaternion rotationOffset;

        public void OnStateEnter(GameObject enemy, EnemyData enemyData)
        {
            this.enemy = enemy;
            this.enemyData = enemyData;
            this.enemyType = enemyData.enemyType;
            this.agent = enemyData.agent;
            this.playerPos = PlayerManager.instance.player.transform.position;
            this.speed = enemyData.speed;
            this.anim = enemyData.anim;
            this.anim.SetBool("chasing", true);
            this.agent.speed = speed;
            this.rotationOffset = new Quaternion(0f, 0f, 0f, 0f);
        }

        public void OnStateExecution()
        {
            Debug.Log("reached execution");
            this.agent.SetDestination(playerPos);
            Debug.Log("set destination");
            this.enemy.transform.LookAt(playerPos);
            this.enemy.transform.rotation = rotationOffset;
        }

        public void OnStateExit()
        {
            this.anim.SetBool("chasing", false);
        }
    }
}
