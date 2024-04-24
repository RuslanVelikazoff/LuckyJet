using UnityEngine;
using UnityEngine.UI;

public class MapInformationPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button backButton;

    [SerializeField] 
    private GameObject mapPanel;
    
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
                panelFunction.OpenPanel(mapPanel, this.gameObject);
            });
        }
    }
}
