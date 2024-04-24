using System;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button pauseButton;
    [SerializeField] 
    private Button continueButton;
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button soundOnButton;
    [SerializeField] 
    private Button soundOffButton;

    [SerializeField] 
    private GameObject pausePanel;

    [SerializeField] 
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;

    private void Awake()
    {
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetVolumeButtonSprites();
    }

    private void ButtonClickAction()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            });
        }

        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                Loader.Load(Loader.CurrentScene());
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
    
    private void SetVolumeButtonSprites()
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
