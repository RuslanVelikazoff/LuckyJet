using UnityEngine;
using UnityEngine.UI;

public class MainThemePanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Button nightButton;
    [SerializeField]
    private Image selectedNighImage;
    
    [SerializeField]
    private Button dayButton;
    [SerializeField]
    private Image selectedDayImage;

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
        SetButtonsSprites();
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

        if (nightButton != null)
        {
            nightButton.onClick.RemoveAllListeners();
            nightButton.onClick.AddListener(() =>
            {
                BackgroundImage.Instance.SetNightSprite();
                SetButtonsSprites();
            });
        }

        if (dayButton != null)
        {
            dayButton.onClick.RemoveAllListeners();
            dayButton.onClick.AddListener(() =>
            {
                BackgroundImage.Instance.SetDaySprite();
                SetButtonsSprites();
            });
        }
    }

    private void SetButtonsSprites()
    {
        if (BackgroundImage.Instance.IsNigh())
        {
            selectedNighImage.sprite = selectedSprite;
            selectedDayImage.sprite = unSelectedSprite;
        }
        else
        {
            selectedNighImage.sprite = unSelectedSprite;
            selectedDayImage.sprite = selectedSprite;
        }
    }
}
