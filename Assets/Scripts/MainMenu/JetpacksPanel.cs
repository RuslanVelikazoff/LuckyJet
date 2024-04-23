using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JetpacksPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Image[] jetpackImages;
    
    [SerializeField]
    private Button[] jetpackBuyButtons;
    [SerializeField] 
    private Button backButton;
    
    [SerializeField]
    private TextMeshProUGUI[] jetpackPriceTexts;
    [SerializeField] 
    private TextMeshProUGUI coinText;
    
    [SerializeField]
    private GameObject[] textsGameObjects;
    [SerializeField]
    private GameObject[] buttonsGameObjects;
    [SerializeField]
    private GameObject[] coinsGameObjects;
    [SerializeField] 
    private GameObject shopPanel;

    [SerializeField]
    private int[] prices;
    private int indexJetpack1 = 0;
    private int indexJetpack2 = 1;
    private int indexJetpack3 = 2;

    [SerializeField]
    private Color lockColor;
    [SerializeField]
    private Color unlockColor;
    
    [SerializeField] 
    private ConfirmPanel confirmPanel;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        SetGameObjects();
        SetCoinText();
    }

    private void SetCoinText()
    {
        coinText.text = Data.Instance.GetCoinAmount().ToString();
    }

    private void SetGameObjects()
    {
        for (int i = 0; i < jetpackPriceTexts.Length; i++)
        {
            if (Data.Instance.IsPurchasedJetpack(i))
            {
                jetpackImages[i].color = unlockColor;
                buttonsGameObjects[i].SetActive(false);
                coinsGameObjects[i].SetActive(false);
                textsGameObjects[i].SetActive(false);
            }
            else
            {
                jetpackImages[i].color = lockColor;
                buttonsGameObjects[i].SetActive(true);
                coinsGameObjects[i].SetActive(true);
                textsGameObjects[i].SetActive(true);
                jetpackPriceTexts[i].text = prices[i].ToString();
            }
        }
    }
    
    public void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            { 
                panelFunction.OpenPanel(shopPanel, this.gameObject);  
            });
        }

        if (jetpackBuyButtons[indexJetpack1] != null)
        {
            jetpackBuyButtons[indexJetpack1].onClick.RemoveAllListeners();
            jetpackBuyButtons[indexJetpack1].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexJetpack1], this.gameObject,
                    BuyJetpack1);
            });
        }
        
        if (jetpackBuyButtons[indexJetpack2] != null)
        {
            jetpackBuyButtons[indexJetpack2].onClick.RemoveAllListeners();
            jetpackBuyButtons[indexJetpack2].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexJetpack2], this.gameObject,
                    BuyJetpack2);
            });
        }
        
        if (jetpackBuyButtons[indexJetpack3] != null)
        {
            jetpackBuyButtons[indexJetpack3].onClick.RemoveAllListeners();
            jetpackBuyButtons[indexJetpack3].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexJetpack3], this.gameObject,
                    BuyJetpack3);
            });
        }
    }
    
    private void BuyJetpack1()
    {
        Data.Instance.BuyJetpack(indexJetpack1, prices[indexJetpack1]);
    }
    
    private void BuyJetpack2()
    {
        Data.Instance.BuyJetpack(indexJetpack2, prices[indexJetpack2]);
    }
    
    private void BuyJetpack3()
    {
        Data.Instance.BuyJetpack(indexJetpack3, prices[indexJetpack3]);
    }
}
