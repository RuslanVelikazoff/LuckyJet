using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoostButton : MonoBehaviour
{
    private float reloadTime = 15f;
    private float startReloadTime = 4f;
    
    [SerializeField]
    private Button boostButton;
    [SerializeField] 
    private PlayerMovement player;

    private IEnumerator Start()
    {
        ButtonClickAction();
        Hide();
        yield return new WaitForSeconds(startReloadTime);
        Show();
    }

    private void ButtonClickAction()
    {
        if (boostButton != null)
        {
            boostButton.onClick.RemoveAllListeners();
            boostButton.onClick.AddListener(() =>
            {
                player.ActivateBoost();
                Hide();
                StartCoroutine(ShowCO());
            });
        }
    }

    private IEnumerator ShowCO()
    {
        yield return new WaitForSeconds(reloadTime);
        player.ActivateBoost();
        Show();
    }

    private void Show()
    {
        boostButton.gameObject.SetActive(true);
    }

    private void Hide()
    {
        boostButton.gameObject.SetActive(false);
    }
}
