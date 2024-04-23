using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoesPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Image[] shoesImages;
    
    [SerializeField]
    private Button[] shoesBuyButtons;
    [SerializeField] 
    private Button backButton;
    
    [SerializeField]
    private TextMeshProUGUI[] shoesPriceTexts;
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
    private int indexShoes1 = 0;
    private int indexShoes2 = 1;
    private int indexShoes3 = 2;

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
        for (int i = 0; i < shoesPriceTexts.Length; i++)
        {
            if (Data.Instance.IsPurchasedShoes(i))
            {
                shoesImages[i].color = unlockColor;
                buttonsGameObjects[i].SetActive(false);
                coinsGameObjects[i].SetActive(false);
                textsGameObjects[i].SetActive(false);
            }
            else
            {
                shoesImages[i].color = lockColor;
                buttonsGameObjects[i].SetActive(true);
                coinsGameObjects[i].SetActive(true);
                textsGameObjects[i].SetActive(true);
                shoesPriceTexts[i].text = prices[i].ToString();
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

        if (shoesBuyButtons[indexShoes1] != null)
        {
            shoesBuyButtons[indexShoes1].onClick.RemoveAllListeners();
            shoesBuyButtons[indexShoes1].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexShoes1], this.gameObject,
                    BuyShoes1);
            });
        }
        
        if (shoesBuyButtons[indexShoes2] != null)
        {
            shoesBuyButtons[indexShoes2].onClick.RemoveAllListeners();
            shoesBuyButtons[indexShoes2].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexShoes2], this.gameObject,
                    BuyShoes2);
            });
        }
        
        if (shoesBuyButtons[indexShoes3] != null)
        {
            shoesBuyButtons[indexShoes3].onClick.RemoveAllListeners();
            shoesBuyButtons[indexShoes3].onClick.AddListener(() =>
            {
                confirmPanel.OpenPanel(prices[indexShoes3], this.gameObject,
                    BuyShoes3);
            });
        }
    }
    
    private void BuyShoes1()
    {
        Data.Instance.BuyShoes(indexShoes1, prices[indexShoes1]);
    }
    
    private void BuyShoes2()
    {
        Data.Instance.BuyShoes(indexShoes2, prices[indexShoes2]);
    }
    
    private void BuyShoes3()
    {
        Data.Instance.BuyShoes(indexShoes3, prices[indexShoes3]);
    }
}
