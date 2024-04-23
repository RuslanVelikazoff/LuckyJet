using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TracksPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Image[] mapImages;
    
    [SerializeField]
    private Button[] mapBuyButtons;
    [SerializeField] 
    private Button backButton;
    
    [SerializeField]
    private TextMeshProUGUI[] mapPriceTexts;
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
    private int indexMap1 = 0;
    private int indexMap2 = 1;
    private int indexMap3 = 2;

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
        for (int i = 0; i < mapPriceTexts.Length; i++)
        {
            if (Data.Instance.IsPurchasedMap(i))
            {
                mapImages[i].color = unlockColor;
                buttonsGameObjects[i].SetActive(false);
                coinsGameObjects[i].SetActive(false);
                textsGameObjects[i].SetActive(false);
            }
            else
            {
                mapImages[i].color = lockColor;
                buttonsGameObjects[i].SetActive(true);
                coinsGameObjects[i].SetActive(true);
                textsGameObjects[i].SetActive(true);
                mapPriceTexts[i].text = prices[i].ToString();
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

        if (mapBuyButtons[indexMap1] != null)
        {
            mapBuyButtons[indexMap1].onClick.RemoveAllListeners();
            mapBuyButtons[indexMap1].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexMap1], this.gameObject,
                    BuyMap1);
            });
        }
        
        if (mapBuyButtons[indexMap2] != null)
        {
            mapBuyButtons[indexMap2].onClick.RemoveAllListeners();
            mapBuyButtons[indexMap2].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexMap2], this.gameObject,
                    BuyMap2);
            });
        }
        
        if (mapBuyButtons[indexMap3] != null)
        {
            mapBuyButtons[indexMap3].onClick.RemoveAllListeners();
            mapBuyButtons[indexMap3].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexMap3], this.gameObject,
                    BuyMap3);
            });
        }
    }

    private void BuyMap1()
    {
        Data.Instance.BuyMap(indexMap1, prices[indexMap1]);
    }
    
    private void BuyMap2()
    {
        Data.Instance.BuyMap(indexMap2, prices[indexMap2]);
    }
    
    private void BuyMap3()
    {
        Data.Instance.BuyMap(indexMap3, prices[indexMap3]);
    }

}
