using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour
{
    public static CoinBar Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI coinText;

    private int coin;

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        SetCoinText();
    }

    private void SetCoinText()
    {
        coinText.text = coin.ToString();
    }

    public void AddCoin()
    {
        coin++;
        Data.Instance.AddCoin(1);
        SetCoinText();
    }

    public int CollectedCoins()
    {
        return coin;
    }
}
