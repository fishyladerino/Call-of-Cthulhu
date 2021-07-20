using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    public class Weapon : MonoBehaviour
    {
        #region WeaponInfo
        public GameObject weapon;
        public GameObject weaponProjectile;
        public GameObject shotPoint;
        public string weaponType;
        public float weaponCooldown;
        public float damage;
        public float weaponRange;
        #endregion

        void Start()
        {
            weapon = gameObject;
            AssignWeaponType();
        }

        void Update()
        {

        }

        public void AssignWeaponType()
        {
            weaponType = weapon.name;
        }
    }
}


