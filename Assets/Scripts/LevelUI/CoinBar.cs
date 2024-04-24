using System.Collections;
using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private int coin;

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
    }

    public int CollectedCoins()
    {
        return coin;
    }
}
