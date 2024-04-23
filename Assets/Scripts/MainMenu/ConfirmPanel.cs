using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button buyButton;

    [SerializeField] 
    private TextMeshProUGUI priceText;
    [SerializeField] 
    private TextMeshProUGUI coinText;

    private GameObject backPanel;

    private Action buyAction;

    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        this.gameObject.SetActive(false);
    }

    public void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(backPanel, this.gameObject);
            });
        }

        if (buyButton != null)
        {
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() =>
            {
                buyAction?.Invoke();
                panelFunction.OpenPanel(backPanel, this.gameObject);
            });
        }
    }

    public void OpenPanel(int price, GameObject backPanel, Action buyAction)
    {
        this.backPanel = backPanel;
        panelFunction.OpenPanel(this.gameObject, backPanel);
        SetBuyAction(buyAction);
        SetPriceText(price);
        SetCoinText();
        ButtonClickAction();
    }
    
    private void SetBuyAction(Action buyAction)
    {
        this.buyAction = buyAction;
    }

    private void SetPriceText(int price)
    {
        priceText.text = price.ToString();
    }

    private void SetCoinText()
    {
        coinText.text = Data.Instance.GetCoinAmount().ToString();
    }
}
