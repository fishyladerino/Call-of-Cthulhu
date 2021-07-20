using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    class PlayerGlide : IPlayerStates
    {
        public float glideGravity = 1;
        public float baseGravity;
        
        public void OnStateEnter()
        {
            baseGravity = PlayerController.instance.gravity;
            PlayerController.instance.gravity = glideGravity;
            PlayerController.instance.isGliding = true;
        }

        public void OnStateExecution()
        {
            
        }

        public void OnStateExit()
        {
            PlayerController.instance.gravity = baseGravity;
            PlayerController.instance.isGliding = false;
        }
    }
}
