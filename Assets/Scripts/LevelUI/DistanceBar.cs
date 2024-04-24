using System;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBar : MonoBehaviour
{
    [SerializeField] private Slider distanceSlider;

    private float currentDistance = 0;

    public void SetSliderInStart(float currentValue, float maxValue)
    {
        distanceSlider.maxValue = maxValue;
        distanceSlider.value = currentValue;
    }

    public void SetWalkingDistance(float walkingDistance)
    {
        currentDistance += walkingDistance;
        distanceSlider.value = currentDistance;
    }
}
