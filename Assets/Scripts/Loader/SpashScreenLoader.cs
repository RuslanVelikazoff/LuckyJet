using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpashScreenLoader : MonoBehaviour
{
    [SerializeField] 
    private Slider loaderSlider;
    
    IEnumerator Start()
    {
        loaderSlider.SetValueWithoutNotify(0);

        yield return new WaitForSeconds(1f);
        
        loaderSlider.SetValueWithoutNotify(.5f);

        yield return new WaitForSeconds(1f);

        loaderSlider.SetValueWithoutNotify(1f);

        SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString());
    }

}
