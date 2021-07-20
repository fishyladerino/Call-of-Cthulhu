using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Player.PlayerScripts
{
    public class PlayerRunning : IPlayerStates
    {
        public float runSpeed = 15f;
        
        public void OnStateEnter()
        {
            PlayerController.instance.anim.SetBool("running", true);
            PlayerController.instance.speed = runSpeed;
        }

        public void OnStateExecution()
        {
            
        }

        public void OnStateExit()
        {
            PlayerController.instance.anim.SetBool("running", false);
        }
    }
}
