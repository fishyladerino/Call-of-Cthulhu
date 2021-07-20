using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    class PlayerAttack : IPlayerStates
    {
        GameObject mainCamera;
        GameObject weapon;
        string weaponType;
        GameObject projectile;
        GameObject shotPoint;
        Quaternion projectileRotation;
        
        public void OnStateEnter()
        {
            mainCamera = GameObject.Find("Main Camera");
            weapon = PlayerController.instance.weapon;
            projectile = PlayerController.instance.projectile;
            shotPoint = PlayerController.instance.shotPoint;
            weaponType = PlayerController.instance.weaponType;
            projectileRotation = new Quaternion(mainCamera.transform.rotation.x, mainCamera.transform.rotation.y, mainCamera.transform.rotation.z, Quaternion.identity.w);
            
            PlayerController.instance.anim.SetBool("attacking", true);
            switch (weaponType)
            {
                case "ranged":
                    GameObject.Instantiate(projectile, shotPoint.transform.position, projectileRotation);
                    break;

                case "melee":
                    //Put melee code here later on (raycast? spherecast? who knows)
                    break;

                case "summon":
                    //Put summoning code here later (Instantiate(summon, companionPoint, quaternion.identity)?
                    break;

                default:
                    break;
            }
        }

        public void OnStateExecution()
        {
            
        }

        public void OnStateExit()
        {
            //PlayerController.anim.SetBool("attacking", false);
        }
    }
}
