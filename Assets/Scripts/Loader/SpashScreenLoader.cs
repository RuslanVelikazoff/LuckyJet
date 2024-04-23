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
    
    private void Update()
    {
        if (timeLeft < timeDownload)
        {
            timeLeft += Time.deltaTime;
            loaderSlider.value = timeLeft;
        }
        else
        {
            SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString());
        }
    }

}
