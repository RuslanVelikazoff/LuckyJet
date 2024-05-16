using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpashScreenLoader : MonoBehaviour
{
    private float timeDownload = 2f;
    private float timeLeft;
    
    [SerializeField] 
    private Slider loaderSlider;

    public bool load = false;

    private void Update()
    {
        if (load)
        {
            if (timeLeft < timeDownload)
            {
                timeLeft += Time.deltaTime;
                loaderSlider.value = timeLeft;
            }
            else
            {
                Screen.orientation = ScreenOrientation.LandscapeRight;
                SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString());
            }
        }
    }

}
