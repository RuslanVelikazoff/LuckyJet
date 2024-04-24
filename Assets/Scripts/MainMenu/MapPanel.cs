using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button continueButton;
    
    [SerializeField]
    private Button nextMapButton;
    [SerializeField] 
    private Button previousMapButton;

    [SerializeField] 
    private Button[] moreInformationButtons;

    [SerializeField]
    private GameObject[] maps;
    [SerializeField] 
    private GameObject[] moreInformationPanels;

    private int currentMapIndex;
    
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        currentMapIndex = Data.Instance.GetSelectedMapIndex();
        ButtonClickAction();
        SetMapImage();
    }

    public void ButtonClickAction()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                StartGame();
            });
        }

        if (nextMapButton != null)
        {
            nextMapButton.onClick.RemoveAllListeners();
            nextMapButton.onClick.AddListener(() =>
            {
                NextMap();
            });
        }

        if (previousMapButton != null)
        {
            previousMapButton.onClick.RemoveAllListeners();
            previousMapButton.onClick.AddListener(() =>
            { 
                PreviousMap();  
            });
        }

        if (moreInformationButtons[currentMapIndex] != null)
        {
            moreInformationButtons[currentMapIndex].onClick.RemoveAllListeners();
            moreInformationButtons[currentMapIndex].onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(moreInformationPanels[currentMapIndex], this.gameObject);
            });
        }
    }

    private void StartGame()
    {
        switch (Data.Instance.GetSelectedMapIndex())
        {
            case 0:
                Loader.Load(Loader.Scene.PinkSunset);
                break;
            case 1: 
                Loader.Load(Loader.Scene.UnknownPlanet);
                break;
            case 2:
                Loader.Load(Loader.Scene.ColdValley);
                break;
        }
    }

    private void SetMapImage()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            if (i == currentMapIndex)
            {
                maps[i].SetActive(true);
            }
            else
            {
                maps[i].SetActive(false);
            }
        }
    }

    private void NextMap()
    {
        int previousMapIndex = currentMapIndex;

        if (currentMapIndex >= maps.Length - 1)
        {
            currentMapIndex = 0;

            if (Data.Instance.IsPurchasedMap(currentMapIndex))
            {
                maps[currentMapIndex].SetActive(true);
                maps[previousMapIndex].SetActive(false);
                Data.Instance.SelectMap(currentMapIndex);
            }
        }
        else
        {
            currentMapIndex++;
            
            if (Data.Instance.IsPurchasedMap(currentMapIndex))
            {
                maps[currentMapIndex].SetActive(true);
                maps[previousMapIndex].SetActive(false);
                Data.Instance.SelectMap(currentMapIndex);
            }
        }
        
        ButtonClickAction();
    }
    
    private void PreviousMap()
    {
        int previousMapIndex = currentMapIndex;
        
        if (currentMapIndex <= 0)
        {
            currentMapIndex = maps.Length - 1;
            
            if (Data.Instance.IsPurchasedMap(currentMapIndex))
            {
                maps[currentMapIndex].SetActive(true);
                maps[previousMapIndex].SetActive(false);
                Data.Instance.SelectMap(currentMapIndex);
            }
        }
        else
        {
            currentMapIndex--;
            
            if (Data.Instance.IsPurchasedMap(currentMapIndex))
            {
                maps[currentMapIndex].SetActive(true);
                maps[previousMapIndex].SetActive(false);
                Data.Instance.SelectMap(currentMapIndex);
            }
        }
        
        ButtonClickAction();
    }
}
