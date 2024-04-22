using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button startButton;
    [SerializeField] 
    private Button settingsButton;
    [SerializeField] 
    private Button moreButton;
    [SerializeField] 
    private Button exitButton;

    [SerializeField]
    private GameObject morePanel;
    [SerializeField] 
    private GameObject settingsPanel;

    private IPanelFunction panelFunction;
    
    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(true);
    }

    public void ButtonClickAction()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                Debug.Log("Start Button");
            });
        }
        
        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(settingsPanel, this.gameObject);
            });
        }
        
        if (moreButton != null)
        {
            moreButton.onClick.RemoveAllListeners();
            moreButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(morePanel, this.gameObject);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
                Debug.Log("Exit Game");
            });
        }
    }
}
