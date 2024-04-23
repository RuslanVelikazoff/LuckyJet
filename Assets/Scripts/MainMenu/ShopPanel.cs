using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button tracksButton;
    [SerializeField] 
    private Button jetpacksButton;
    [SerializeField] 
    private Button shoesButton;
    [SerializeField] 
    private Button backButton;
    
    [SerializeField] 
    private GameObject morePanel;
    [SerializeField]
    private GameObject tracksPanel;
    [SerializeField]
    private GameObject jetpacksPanel;
    [SerializeField] 
    private GameObject shoesPanel;

    [SerializeField] 
    private TextMeshProUGUI coinText;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetCoinText();
    }

    public void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(morePanel, this.gameObject);
            });
        }

        if (tracksButton != null)
        {
            tracksButton.onClick.RemoveAllListeners();
            tracksButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(tracksPanel, this.gameObject);
            });
        }

        if (jetpacksButton != null)
        {
            jetpacksButton.onClick.RemoveAllListeners();
            jetpacksButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(jetpacksPanel, this.gameObject);
            });
        }

        if (shoesButton != null)
        {
            shoesButton.onClick.RemoveAllListeners();
            shoesButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(shoesPanel, this.gameObject);
            });
        }
    }

    private void SetCoinText()
    {
        coinText.text = Data.Instance.GetCoinAmount().ToString();
    }
}
