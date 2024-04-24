using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button menuButton;

    [SerializeField] 
    private TextMeshProUGUI coinText;

    [SerializeField] 
    private GameObject gameOverPanel;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ButtonClickAction();
    }

    public void OpenPanel(int currentCoin)
    {
        gameOverPanel.SetActive(true);
        coinText.text = currentCoin.ToString();
    }

    private void ButtonClickAction()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                Loader.Load(Loader.CurrentScene());
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                Loader.Load(Loader.Scene.MainMenuScene);
            });
        }
    }
}
