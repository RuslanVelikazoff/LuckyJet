using UnityEngine;
using UnityEngine.UI;

public class MorePanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Button shopButton;
    [SerializeField] 
    private Button recordsButton;
    [SerializeField]
    private Button helpButton;
    [SerializeField]
    private Button backButton;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject shopPanel;
    [SerializeField]
    private GameObject recordsPanel;
    [SerializeField] 
    private GameObject helpPanel;

    private IPanelFunction panelFunction;
    
    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    public void ButtonClickAction()
    {
        if (shopButton != null)
        {
            shopButton.onClick.RemoveAllListeners();
            shopButton.onClick.AddListener(() =>
            {
                Debug.Log("Shop button");
            });
        }
        
        if (recordsButton != null)
        {
            recordsButton.onClick.RemoveAllListeners();
            recordsButton.onClick.AddListener(() =>
            {
                Debug.Log("Record button");
            });
        }
        
        if (helpButton != null)
        {
            helpButton.onClick.RemoveAllListeners();
            helpButton.onClick.AddListener(() =>
            {
                Debug.Log("Help button");
            });
        }
        
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(mainPanel, this.gameObject);
            });
        }
    }
}
