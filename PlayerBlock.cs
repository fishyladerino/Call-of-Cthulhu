using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    class PlayerBlock : IPlayerStates
    {
        public void OnStateEnter()
        {
            PlayerController.instance.anim.SetBool("blocking", true);
            PlayerController.instance.isBlocking = true;
        }

        public void OnStateExecution()
        {
            
        }

        public void OnStateExit()
        {
            PlayerController.instance.anim.SetBool("blocking", false);
            PlayerController.instance.isBlocking = false;
        }
    }
}
