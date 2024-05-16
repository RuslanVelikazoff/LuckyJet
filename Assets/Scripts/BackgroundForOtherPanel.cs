using UnityEngine;
using UnityEngine.UI;

public class BackgroundForOtherPanel : MonoBehaviour
{
    public Button backButton;
    public Button forwardButton;

    public PolicyController policyWebView;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                policyWebView.GoBack();
            });
        }

        if (forwardButton != null)
        {
            forwardButton.onClick.RemoveAllListeners();
            forwardButton.onClick.AddListener(() =>
            {
                policyWebView.GoForward();
            });
        }
    }
}
