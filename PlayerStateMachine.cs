/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    protected PlayerStates PlayerStates;

    public void SetPlayerStates(PlayerStates playerStates)
    {
        PlayerStates = playerStates;
        StartCoroutine(playerStates.Idle());
    }
}*/
 