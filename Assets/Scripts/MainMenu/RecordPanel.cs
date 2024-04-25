using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button deleteButton;

    [SerializeField] 
    private TextMeshProUGUI[] recordTexts;

    [SerializeField] 
    private GameObject morePanel;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetRecordsText();
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

        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                Data.Instance.ClearRecords();
                SetRecordsText();
            });
        }
    }

    private void SetRecordsText()
    {
        for (int i = 0; i < recordTexts.Length; i++)
        {
            if (Data.Instance.GetHighScoreByIndex(i) == 0)
            {
                recordTexts[i].text = "?";
            }
            else
            {
                recordTexts[i].text = Data.Instance.GetHighScoreByIndex(i).ToString();
            }
        }
    }
}
