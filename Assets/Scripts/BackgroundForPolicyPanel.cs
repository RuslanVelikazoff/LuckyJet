using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundForPolicyPanel : MonoBehaviour
{
    public Button agreeButton;

    public PolicyController policyWebView;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (agreeButton != null)
        {
            agreeButton.onClick.RemoveAllListeners();
            agreeButton.onClick.AddListener(() =>
            {
                policyWebView.ConfirmPolicy();
            });
        }
    }
}
