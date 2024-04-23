using System;
using UnityEngine;
using UnityEngine.UI;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField] 
    private Slider downloadSlider;
    
    private float timeDownload = 2f;
    private float timeLeft;

    private void Update()
    {
        if (timeLeft < timeDownload)
        {
            timeLeft += Time.deltaTime;
            downloadSlider.value = timeLeft;
        }
        else
        {
            Loader.LoaderCallback();
        }
    }
}
