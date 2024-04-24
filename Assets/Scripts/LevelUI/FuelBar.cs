using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] 
    private Slider fuelSlider;
    
    public void SetFuelSlider(float maxFuel, float currentFuel)
    {
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = currentFuel;
    }

    public void SetCurrentFuel(float currentFuel)
    {
        fuelSlider.value = currentFuel;
    }

    public void AddFuel(int addedFuel)
    {
        fuelSlider.value += addedFuel;
    }
}
