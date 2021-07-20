using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    public class PlayerIdle : IPlayerStates
    {
        public void OnStateEnter()
        {
            PlayerController.instance.anim.SetBool("idle", true);
        }

        public void OnStateExecution()
        {

        }

        public void OnStateExit()
        {
            PlayerController.instance.anim.SetBool("idle", false);
        }
    }
}
