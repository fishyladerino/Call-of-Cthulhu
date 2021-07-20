using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    class PlayerJump : IPlayerStates
    {
        public float jumpHeight = 4f;

        public void OnStateEnter()
        {
            PlayerController.instance.velocity.y = Mathf.Sqrt(jumpHeight * -2f * PlayerController.instance.gravity);
            PlayerController.instance.weapon.GetComponent<WeaponAnimator>().Jump();
        }

        public void OnStateExecution()
        {
            
        }

        public void OnStateExit()
        {
            
        }
    }
}
