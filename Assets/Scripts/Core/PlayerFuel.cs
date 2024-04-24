using System;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    private float maxFuel = 35f;
    private float currentFuel = 35f;

    [SerializeField]
    private FuelBar fuelBar;

    private void Awake()
    {
        fuelBar.SetFuelSlider(maxFuel, currentFuel);
    }

    private void Update()
    {
        currentFuel -= Time.deltaTime;
        fuelBar.SetCurrentFuel(currentFuel);

        if (currentFuel <= 0)
        {
            GameManager.Instance.LoseGame();
        }
    }
}
