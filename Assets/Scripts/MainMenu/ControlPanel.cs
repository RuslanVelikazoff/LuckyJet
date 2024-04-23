using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Button classicButton;
    [SerializeField] 
    private Image selectedClassicImage;

    [SerializeField] 
    private Button expertButton;
    [SerializeField] 
    private Image selectedExpertImage;

    [SerializeField]
    private Button backButton;

    [SerializeField] 
    private GameObject settingsPanel;

    [SerializeField] 
    private Sprite selectedSprite;
    [SerializeField] 
    private Sprite unSelectedSprite;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetButtonsSprite();
    }

    public void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(settingsPanel, this.gameObject);
            });
        }

        if (classicButton != null)
        {
            classicButton.onClick.RemoveAllListeners();
            classicButton.onClick.AddListener(() =>
            {
                ControlManager.Instance.SetControlClassic();
                SetButtonsSprite();
            });
        }

        if (expertButton != null)
        {
            expertButton.onClick.RemoveAllListeners();
            expertButton.onClick.AddListener(() =>
            {
                ControlManager.Instance.SetControlExpert();
                SetButtonsSprite();
            });
        }
    }

    private void SetButtonsSprite()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            selectedClassicImage.sprite = selectedSprite;
            selectedExpertImage.sprite = unSelectedSprite;
        }
        else
        {
            selectedClassicImage.sprite = unSelectedSprite;
            selectedExpertImage.sprite = selectedSprite;
        }
    }
}
