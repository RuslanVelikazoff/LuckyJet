using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour, IPanelFunction
{
    [SerializeField] 
    private Button nextCharacterButton;
    [SerializeField] 
    private Button previousCharacterButton;
    
    [SerializeField] 
    private Button nextJetpackButton;
    [SerializeField] 
    private Button previousJetpackButton;
    
    [SerializeField] 
    private Button nextShoesButton;
    [SerializeField] 
    private Button previousShoesButton;
    
    [SerializeField] 
    private Button continueButton;

    [SerializeField]
    private GameObject[] characters;
    [SerializeField]
    private GameObject[] jetpacks;
    [SerializeField]
    private GameObject[] shoes;
    
    
    [SerializeField]
    private GameObject mapPanel;

    private int currentCharacterIndex;
    private int currentJetpackIndex;
    private int currentShoesIndex;
    
    private IPanelFunction panelFunction;

    private void Awake()
    {
        panelFunction = this;
        ButtonClickAction();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        currentCharacterIndex = Data.Instance.GetCharacterIndex();
        currentJetpackIndex = Data.Instance.GetJetpackIndex();
        currentShoesIndex = Data.Instance.GetShoesIndex();
        
        SetCharacterImage();
        SetJetpackImage();
        SetShoesImage();
    }

    public void ButtonClickAction()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                panelFunction.OpenPanel(mapPanel, this.gameObject);
            });
        }

        if (nextCharacterButton != null)
        {
            nextCharacterButton.onClick.RemoveAllListeners();
            nextCharacterButton.onClick.AddListener(() =>
            {
                nextCharacter();
            });
        }

        if (previousCharacterButton != null)
        {
            previousCharacterButton.onClick.RemoveAllListeners();
            previousCharacterButton.onClick.AddListener(() =>
            {
                previousCharacter();
            });
        }

        if (nextJetpackButton != null)
        {
            nextJetpackButton.onClick.RemoveAllListeners();
            nextJetpackButton.onClick.AddListener(() =>
            {
                nextJetpack();
            });
        }

        if (previousJetpackButton != null)
        {
            previousJetpackButton.onClick.RemoveAllListeners();
            previousJetpackButton.onClick.AddListener(() =>
            {
                previousJetpack();
            });
        }

        if (nextShoesButton != null)
        {
            nextShoesButton.onClick.RemoveAllListeners();
            nextShoesButton.onClick.AddListener(() =>
            {
                nextShoes();
            });
        }

        if (previousShoesButton != null)
        {
            previousShoesButton.onClick.RemoveAllListeners();
            previousShoesButton.onClick.AddListener(() =>
            {
                previousShoes();
            });
        }
    }

    private void SetCharacterImage()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == currentCharacterIndex)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }

    private void nextCharacter()
    {
        int previousCharacterIndex = currentCharacterIndex;
        
        if (currentCharacterIndex >= characters.Length - 1)
        {
            currentCharacterIndex = 0;
            
            if (Data.Instance.IsPurchasedCharacter(currentCharacterIndex))
            {
                characters[currentCharacterIndex].SetActive(true);
                characters[previousCharacterIndex].SetActive(false);
                Data.Instance.SelectCharacter(currentCharacterIndex);
            }
        }
        else
        {
            currentCharacterIndex++;
            
            if (Data.Instance.IsPurchasedCharacter(currentCharacterIndex))
            {
                characters[currentCharacterIndex].SetActive(true);
                characters[previousCharacterIndex].SetActive(false);
                Data.Instance.SelectCharacter(currentCharacterIndex);
            }
        }
    }
    
    private void previousCharacter()
    {
        int previousCharacterIndex = currentCharacterIndex;
        
        if (currentCharacterIndex <= 0)
        {
            currentCharacterIndex = characters.Length - 1;
            
            if (Data.Instance.IsPurchasedCharacter(currentCharacterIndex))
            {
                characters[currentCharacterIndex].SetActive(true);
                characters[previousCharacterIndex].SetActive(false);
                Data.Instance.SelectCharacter(currentCharacterIndex);
            }
        }
        else
        {
            currentCharacterIndex--;
            
            if (Data.Instance.IsPurchasedCharacter(currentCharacterIndex))
            {
                characters[currentCharacterIndex].SetActive(true);
                characters[previousCharacterIndex].SetActive(false);
                Data.Instance.SelectCharacter(currentCharacterIndex);
            }
        }
    }
    
    private void SetJetpackImage()
    {
        for (int i = 0; i < jetpacks.Length; i++)
        {
            if (i == currentJetpackIndex)
            {
                jetpacks[i].SetActive(true);
            }
            else
            {
                jetpacks[i].SetActive(false);
            }
        }
    }

    private void nextJetpack()
    {
        int previousJetpackIndex = currentJetpackIndex;
        
        if (currentJetpackIndex >= jetpacks.Length - 1)
        {
            currentJetpackIndex = 0;
            
            if (Data.Instance.IsPurchasedJetpack(currentJetpackIndex))
            {
                jetpacks[currentJetpackIndex].SetActive(true);
                jetpacks[previousJetpackIndex].SetActive(false);
                Data.Instance.SelectJetpack(currentJetpackIndex);
            }
        }
        else
        {
            currentJetpackIndex++;
            
            if (Data.Instance.IsPurchasedJetpack(currentJetpackIndex))
            {
                jetpacks[currentJetpackIndex].SetActive(true);
                jetpacks[previousJetpackIndex].SetActive(false);
                Data.Instance.SelectJetpack(currentJetpackIndex);
            }
        }
    }
    
    private void previousJetpack()
    {
        int previousJetpackIndex = currentJetpackIndex;
        
        if (currentJetpackIndex <= 0)
        {
            currentJetpackIndex = jetpacks.Length - 1;
            
            if (Data.Instance.IsPurchasedJetpack(currentJetpackIndex))
            {
                jetpacks[currentJetpackIndex].SetActive(true);
                jetpacks[previousJetpackIndex].SetActive(false);
                Data.Instance.SelectJetpack(currentJetpackIndex);
            }
        }
        else
        {
            currentJetpackIndex--;
            
            if (Data.Instance.IsPurchasedJetpack(currentJetpackIndex))
            {
                jetpacks[currentJetpackIndex].SetActive(true);
                jetpacks[previousJetpackIndex].SetActive(false);
                Data.Instance.SelectJetpack(currentJetpackIndex);
            }
        }
    }
    
    private void SetShoesImage()
    {
        for (int i = 0; i < shoes.Length; i++)
        {
            if (i == currentShoesIndex)
            {
                shoes[i].SetActive(true);
            }
            else
            {
                shoes[i].SetActive(false);
            }
        }
    }

    private void nextShoes()
    {
        int previousShoesIndex = currentShoesIndex;
        
        if (currentShoesIndex >= shoes.Length - 1)
        {
            currentShoesIndex = 0;
            
            if (Data.Instance.IsPurchasedShoes(currentShoesIndex))
            {
                shoes[currentShoesIndex].SetActive(true);
                shoes[previousShoesIndex].SetActive(false);
                Data.Instance.SelectShoes(currentShoesIndex);
            }
        }
        else
        {
            currentShoesIndex++;
            
            if (Data.Instance.IsPurchasedShoes(currentShoesIndex))
            {
                shoes[currentShoesIndex].SetActive(true);
                shoes[previousShoesIndex].SetActive(false);
                Data.Instance.SelectShoes(currentShoesIndex);
            }
        }
    }
    
    private void previousShoes()
    {
        int previousShoesIndex = currentShoesIndex;
        
        if (currentShoesIndex <= 0)
        {
            currentShoesIndex = shoes.Length - 1;
            
            if (Data.Instance.IsPurchasedShoes(currentShoesIndex))
            {
                shoes[currentShoesIndex].SetActive(true);
                shoes[previousShoesIndex].SetActive(false);
                Data.Instance.SelectShoes(currentShoesIndex);
            }
        }
        else
        {
            currentShoesIndex--;
            
            if (Data.Instance.IsPurchasedShoes(currentShoesIndex))
            {
                shoes[currentShoesIndex].SetActive(true);
                shoes[previousShoesIndex].SetActive(false);
                Data.Instance.SelectShoes(currentShoesIndex);
            }
        }
    }
}
