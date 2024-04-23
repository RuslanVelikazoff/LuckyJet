using UnityEngine;
using UnityEngine.UI;

public class GamemodePanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button backButton;
    [SerializeField]
    private Button competitiveButton;
    [SerializeField] 
    private Button singleButton;
    [SerializeField] 
    private Button limitedTimeButton;

    [SerializeField] 
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject characterPanel;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    public void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(mainMenuPanel, this.gameObject);
            });
        }

        if (competitiveButton != null)
        {
            competitiveButton.onClick.RemoveAllListeners();
            competitiveButton.onClick.AddListener(() =>
            {
                GamemodeManager.Instance.SelectCompetitiveGamemode();
                panelFunction.OpenPanel(characterPanel, this.gameObject);
            });
        }

        if (singleButton != null)
        {
            singleButton.onClick.RemoveAllListeners();
            singleButton.onClick.AddListener(() =>
            {
                GamemodeManager.Instance.SelectedSingleGamemode();
                panelFunction.OpenPanel(characterPanel, this.gameObject);
            });
        }

        if (limitedTimeButton != null)
        {
            limitedTimeButton.onClick.RemoveAllListeners();
            limitedTimeButton.onClick.AddListener(() =>
            {
                GamemodeManager.Instance.SelectedLimitedTimeGamemode();
                panelFunction.OpenPanel(characterPanel, this.gameObject);
            });
        }
    }
}
