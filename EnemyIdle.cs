using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Enemys.EnemyScripts
{
    public class EnemyIdle : IEnemyStates
    {
        Animator anim;

        public void OnStateEnter(GameObject enemy, EnemyData enemyData)
        {
            this.anim = enemyData.anim;
            this.anim.SetBool("idle", true);
        }

        public void OnStateExecution()
        {
            
        }

        public void OnStateExit()
        {
            //this.anim.SetBool("idle", false);
        }
    }
}
