using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private const string saveKey = "MainSave";
    
    public bool[] _selectedCharacter;
    public bool[] _selectedJetpack;
    public bool[] _selectedShoes;
    public bool[] _selectedMap;

    public bool[] _purchasedCharacter;
    public bool[] _purchasedJetpack;
    public bool[] _purchasedShoes;
    public bool[] _purchasedMap;

    public int _coin;

    public int _highScore;

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(saveKey);

        _selectedCharacter = data.selectedCharacter;
        _selectedJetpack = data.selectedJetpack;
        _selectedShoes = data.selectedShoes;
        _selectedMap = data.selectedMap;

        _purchasedCharacter = data.purchasedCharacter;
        _purchasedJetpack = data.purchasedJetpack;
        _purchasedShoes = data.purchasedShoes;
        _purchasedMap = data.purchasedMap;

        _coin = data.coin;
        _highScore = data.highScore;
        
        Debug.Log("Loading data");
    }

    public void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Save data");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            selectedCharacter = _selectedCharacter,
            selectedJetpack = _selectedJetpack,
            selectedShoes = _selectedShoes,
            selectedMap = _selectedMap,
            
            purchasedCharacter = _purchasedCharacter,
            purchasedJetpack = _purchasedJetpack,
            purchasedShoes = _purchasedShoes,
            purchasedMap = _purchasedMap,
            
            coin = _coin,
            highScore = _highScore
        };

        return data;
    }

    public int GetCoinAmount()
    {
        return _coin;
    }

    public bool BuyItem(int price)
    {
        if (_coin >= price)
        {
            _coin = _coin - price;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPurchasedMap(int index)
    {
        if (_purchasedMap[index])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPurchasedJetpack(int index)
    {
        if (_purchasedJetpack[index])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPurchasedShoes(int index)
    {
        if (_purchasedShoes[index])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPurchasedCharacter(int index)
    {
        if (_purchasedCharacter[index])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyMap(int index, int price)
    {
        if (!IsPurchasedMap(index))
        {
            if (BuyItem(price))
            {
                _purchasedMap[index] = true;
                Save();
            }
        }
    }

    public void BuyJetpack(int index, int price)
    {
        if (!IsPurchasedJetpack(index))
        {
            if (BuyItem(price))
            {
                _purchasedJetpack[index] = true;
                Save();
            }
        }
    }

    public void BuyShoes(int index, int price)
    {
        if (!IsPurchasedShoes(index))
        {
            if (BuyItem(price))
            {
                _purchasedShoes[index] = true;
                Save();
            }
        }
    }

    public void SelectCharacter(int index)
    {
        if (IsPurchasedCharacter(index))
        {
            for (int i = 0; i < _selectedCharacter.Length; i++)
            {
                if (i == index)
                {
                    _selectedCharacter[i] = true;
                }
                else
                {
                    _selectedCharacter[i] = false;
                }
            }
        }
    }

    public int GetJetpackIndex()
    {
        for (int i = 0; i < _selectedJetpack.Length; i++)
        {
            if (_selectedJetpack[i])
            {
                return i;
                break;
            }
        }

        return 0;
    }
    
    public void SelectJetpack(int index)
    {
        if (IsPurchasedJetpack(index))
        {
            for (int i = 0; i < _selectedJetpack.Length; i++)
            {
                if (i == index)
                {
                    _selectedJetpack[i] = true;
                }
                else
                {
                    _selectedJetpack[i] = false;
                }
            }
        }
    }

    public int GetCharacterIndex()
    {
        for (int i = 0; i < _selectedCharacter.Length; i++)
        {
            if (_selectedCharacter[i])
            {
                return i;
                break;
            }
        }

        return 0;
    }
    
    public void SelectShoes(int index)
    {
        if (IsPurchasedShoes(index))
        {
            for (int i = 0; i < _selectedShoes.Length; i++)
            {
                if (i == index)
                {
                    _selectedShoes[i] = true;
                }
                else
                {
                    _selectedShoes[i] = false;
                }
            }
        }
    }

    public int GetShoesIndex()
    {
        for (int i = 0; i < _selectedShoes.Length; i++)
        {
            if (_selectedShoes[i])
            {
                return i;
                break;
            }
        }

        return 0;
    }
}
