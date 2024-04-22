using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button mainThemeButton;
    [SerializeField] 
    private Button controlButton;
    [SerializeField] 
    private Button soundOnButton;
    [SerializeField]
    private Button soundOffButton;
    [SerializeField] 
    private Button backButton;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject mainThemePanel;
    [SerializeField] 
    private GameObject controlPanel;

    [SerializeField] 
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetVolumeButtonSprites();
    }

    public void ButtonClickAction()
    {
        if (mainThemeButton != null)
        {
            mainThemeButton.onClick.RemoveAllListeners();
            mainThemeButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(mainThemePanel, this.gameObject);
            });
        }

        if (controlButton != null)
        {
            controlButton.onClick.RemoveAllListeners();
            controlButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(controlPanel, this.gameObject);
            });
        }

        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(mainPanel, this.gameObject);
            });
        }

        if (soundOnButton != null)
        {
            soundOnButton.onClick.RemoveAllListeners();
            soundOnButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.OnSounds();
                SetVolumeButtonSprites();
            });
        }

        if (soundOffButton != null)
        {
            soundOffButton.onClick.RemoveAllListeners();
            soundOffButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.OffSounds();
                SetVolumeButtonSprites();
            });
        }
    }

    public void SetVolumeButtonSprites()
    {
        if (AudioManager.Instance.SoundPlay())
        {
            soundOnButton.GetComponent<Image>().color = activeColor;
            soundOffButton.GetComponent<Image>().color = inactiveColor;
        }
        else
        {
            soundOnButton.GetComponent<Image>().color = inactiveColor;
            soundOffButton.GetComponent<Image>().color = activeColor;
        }
    }
}
