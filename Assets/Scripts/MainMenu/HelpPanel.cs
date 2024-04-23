using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private GameObject morePanel;
    
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
                panelFunction.OpenPanel(morePanel, this.gameObject);
            });
        }
    }
}
