using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Projectile : MonoBehaviour
    {
        #region Components
        CharacterController controller;
        #endregion

        #region BulletInfo
        Vector3 bulletMovement;
        Vector3 velocity;
        public float travelSpeed;
        public float bulletGravity;
        public bool isBouncy;
        public float hitDistance;
        #endregion

        public void Start()
        {
            controller = GetComponent<CharacterController>();
        }
        
        public void Update()
        {
            bulletMovement = transform.forward;
            controller.Move(bulletMovement * travelSpeed * Time.deltaTime);

            //collision bouncing check
            /**if (isBouncy)
            {
                if (Physics.Raycast(new Ray(transform.position, transform.right), hitDistance))
                {
                    bulletMovement = -bulletMovement;
                }
            }*/

            //gravity
            velocity.y += bulletGravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
