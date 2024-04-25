using System;
using System.Collections;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    private float maxFuel = 35f;
    private float currentFuel = 35f;

    [SerializeField]
    private FuelBar fuelBar;

    private void Update()
    {
        currentFuel -= Time.deltaTime;
        fuelBar.SetCurrentFuel(currentFuel);

        if (currentFuel <= 0)
        {
            GameManager.Instance.LoseGame();
        }
    }

    public void SetPlayerFuel(float currentFuel)
    {
        this.currentFuel = currentFuel;
        fuelBar.SetFuelSlider(maxFuel, this.currentFuel);
    }

    public void AddFuel()
    {
        float addedFuel = 4f;
        currentFuel += addedFuel;
        fuelBar.SetFuelSlider(maxFuel, currentFuel);
    }
}
