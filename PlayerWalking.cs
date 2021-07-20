using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    class PlayerWalking : IPlayerStates
    {
        public float walkSpeed = 7f;

        public void OnStateEnter()
        {
            PlayerController.instance.anim.SetBool("walking", true);
            PlayerController.instance.speed = walkSpeed;
        }

        public void OnStateExecution()
        {

        }

        public void OnStateExit()
        {
            PlayerController.instance.anim.SetBool("walking", false);
        }
    }
}
