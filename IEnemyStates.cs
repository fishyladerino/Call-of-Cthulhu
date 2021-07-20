using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemys.EnemyScripts
{
    public interface IEnemyStates
    {
        public void OnStateEnter(GameObject enemy, EnemyData enemyData);
        public void OnStateExecution();
        public void OnStateExit();
    }
}
