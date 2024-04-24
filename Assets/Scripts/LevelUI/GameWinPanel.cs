using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWinPanel : MonoBehaviour
{
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button menuButton;

    [SerializeField] 
    private TextMeshProUGUI coinText;

    [SerializeField] 
    private GameObject gameWinPanel;

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
        gameWinPanel.SetActive(true);
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
