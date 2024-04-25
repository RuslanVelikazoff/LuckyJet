using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private GameOverPanel gameOverPanel;
    [SerializeField] 
    private GameWinPanel gameWinPanel;
    
    [SerializeField] 
    private CoinBar coinBar;

    private void Awake()
    {
        Instance = this;
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        Data.Instance.AddCoin(coinBar.CollectedCoins());
        gameOverPanel.OpenPanel(coinBar.CollectedCoins());
        Data.Instance.NewRecord(coinBar.CollectedCoins());
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        Data.Instance.AddCoin(coinBar.CollectedCoins());
        gameWinPanel.OpenPanel(coinBar.CollectedCoins());
        Data.Instance.NewRecord(coinBar.CollectedCoins());
    }
}
