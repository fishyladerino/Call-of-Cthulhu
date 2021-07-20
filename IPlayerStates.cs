using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Player.PlayerScripts
{
    public interface IPlayerStates
    {
        public void OnStateEnter();
        public void OnStateExecution();
        public void OnStateExit();
    }
}

