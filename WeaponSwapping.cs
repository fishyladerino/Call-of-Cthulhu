using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    public class WeaponSwapping : MonoBehaviour
    {
        public float selectedIndex;
        public GameObject player;
        public bool weaponSwitched;
        public float swapCooldown;
        float cooldownTime;

        // Start is called before the first frame update
        void Start()
        {
            SelectWeapon();
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            //if user inputs num, assigns it to selected index
            if (Input.inputString != null )
            {
                string str = Input.inputString;

                if (float.TryParse(str, out float num) && cooldownTime <= 0)
                {
                    selectedIndex = num - 1;
                    weaponSwitched = true;
                    cooldownTime = swapCooldown;
                }
                else cooldownTime -= Time.deltaTime;
            }

            //assigns new weapon anim to playercontroller
            if (weaponSwitched)
            {
                SelectWeapon();
                weaponSwitched = false;
            }
        }

        public void SelectWeapon()
        {
            int iteratorIndex = 0;

            //iterates through children of spawner and activates selected one
            foreach (Transform weapon in transform)
            {
                if (iteratorIndex == selectedIndex)
                {
                    weapon.gameObject.SetActive(true);
                    player.GetComponent<PlayerController>().OnWeaponSwitch();
                }
                else weapon.gameObject.SetActive(false);

                iteratorIndex++;
            }
        }
    }
}
