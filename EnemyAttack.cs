using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemys.EnemyScripts
{
    public class EnemyAttack : IEnemyStates
    {
        GameObject enemy;
        EnemyData enemyData;
        Animator anim;
        string enemyType;
        GameObject projectile;
        Quaternion projectileRotation;

        public void OnStateEnter(GameObject enemy, EnemyData enemyData)
        {
            this.enemyData = enemyData;
            this.enemy = enemy;
            enemyType = enemyData.enemyType;
            projectile = enemyData.projectile;
            anim = enemyData.anim;
            anim.SetBool("attacking", true);
            projectileRotation = new Quaternion(enemy.transform.rotation.x, enemy.transform.rotation.y, Quaternion.identity.z, Quaternion.identity.w);

        }

        public void OnStateExecution()
        {
            /**switch (enemyType)
            {
                case "ranged":
                    if (enemyData.timeBtwShots == 0)
                    {
                        GameObject.Instantiate(projectile, enemyData.shotPoint.transform.position, Quaternion.identity);
                        enemyData.timeBtwShots = enemyData.startTimeBtwShots;
                    }
                    else enemyData.timeBtwShots -= Time.deltaTime;
                    break;
                
                default:
                    break;
            }
            */
        }

        public void OnStateExit()
        {
            anim.SetBool("attacking", false);
        }
    }
}
