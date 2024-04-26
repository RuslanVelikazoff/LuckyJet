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
    [SerializeField] 
    private TemplateSpawner templateSpawner;

    private float maxDistance;
    private float playerSpeed;
    private float playerWalkingDistance;
    private float templateSpeed;

    private float playerBoostSpeed;
    private float playerBoostWalkingDistance;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        
        SetMaxDistance();
        SetPlayerFuel();
        SetPlayerMovement();
        SetPlayerBoostMovement();
        SetTemplateSpeed();
    }

    private void SetTemplateSpeed()
    {
        switch (Data.Instance.GetCharacterIndex())
        {
            default:
            case 0:
                templateSpeed = 3;
                templateSpawner.SetTemplateSpeed(templateSpeed);
                break;
            case 1:
                templateSpeed = 6;
                templateSpawner.SetTemplateSpeed(templateSpeed);
                break;
            case 2:
                templateSpeed = 9;
                templateSpawner.SetTemplateSpeed(templateSpeed);
                break;
        }
    }

    private void SetMaxDistance()
    {
        switch (Data.Instance.GetSelectedMapIndex())
        {
            default:
            case 0:
                maxDistance = 2000f;
                break;
            case 1:
                maxDistance = 3000f;
                break;
            case 2:
                maxDistance = 4000f;
                break;
        }
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
                playerSpeed = 3f;
                playerWalkingDistance = .1f;
                playerMovement.SetPlayerMovement(playerSpeed, playerWalkingDistance, maxDistance);
                break;
            case 1:
                playerSpeed = 6f;
                playerWalkingDistance = .2f;
                playerMovement.SetPlayerMovement(playerSpeed, playerWalkingDistance, maxDistance);
                break;
            case 2:
                playerSpeed = 9f;
                playerWalkingDistance = .3f;
                playerMovement.SetPlayerMovement(playerSpeed, playerWalkingDistance, maxDistance);
                break;
        }
    }

    private void SetPlayerBoostMovement()
    {
        switch (Data.Instance.GetShoesIndex())
        {
            default:
            case 0:
                playerBoostSpeed = playerSpeed + .3f;
                playerBoostWalkingDistance = playerWalkingDistance + .04f;
                playerMovement.SetPlayerBoostMovement(playerBoostSpeed, playerWalkingDistance);
                break;
            case 1:
                playerBoostSpeed = playerSpeed + .6f;
                playerBoostWalkingDistance = playerWalkingDistance + .08f;
                playerMovement.SetPlayerBoostMovement(playerBoostSpeed, playerWalkingDistance);
                break;
            case 2:
                playerBoostSpeed = playerSpeed + 1;
                playerBoostWalkingDistance = playerWalkingDistance + .12f;
                playerMovement.SetPlayerBoostMovement(playerBoostSpeed, playerWalkingDistance);
                break;
        }
    }
}
