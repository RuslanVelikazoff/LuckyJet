using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerStatsManager : MonoBehaviour
{
    [SerializeField]
    private PlayerFuel playerFuel;
    [SerializeField] 
    private PlayerMovement playerMovement;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        
        SetPlayerFuel();
        SetPlayerMovement();
    }

    private void SetPlayerFuel()
    {
        switch (Data.Instance.GetJetpackIndex())
        {
            default:
            case 0:
                float fuelJetpack1 = 15f;
                playerFuel.SetPlayerFuel(fuelJetpack1);
                break;
            case 1:
                float fuelJetpack2 = 23f;
                playerFuel.SetPlayerFuel(fuelJetpack2);
                break;
            case 2:
                float fuelJetpack3 = 35f;
                playerFuel.SetPlayerFuel(fuelJetpack3);
                break;
        }
    }

    private void SetPlayerMovement()
    {
        switch (Data.Instance.GetJetpackIndex())
        {
            default:
            case 0:
                float playerSpeed1 = 3f;
                float playerWalkingDistance1 = .1f;
                playerMovement.SetPlayerMovement(playerSpeed1, playerWalkingDistance1);
                break;
            case 1:
                float playerSpeed2 = 6f;
                float playerWalkingDistance2 = .2f;
                playerMovement.SetPlayerMovement(playerSpeed2, playerWalkingDistance2);
                break;
            case 2:
                float playerSpeed3 = 9f;
                float playerWalkingDistance3 = .3f;
                playerMovement.SetPlayerMovement(playerSpeed3, playerWalkingDistance3);
                break;
        }
    }
}
