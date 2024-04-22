using UnityEngine;

public class Data : MonoBehaviour
{
    //Добавить методы для выбора джойстика и заднего фона
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

    public bool[] _purchasedCharacter;
    public bool[] _purchasedJetpack;
    public bool[] _purchasedShoes;

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

        _purchasedCharacter = data.purchasedCharacter;
        _purchasedJetpack = data.purchasedJetpack;
        _purchasedShoes = data.purchasedShoes;

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
            
            purchasedCharacter = _purchasedCharacter,
            purchasedJetpack = _purchasedJetpack,
            purchasedShoes = _purchasedShoes,
            
            coin = _coin,
            highScore = _highScore
        };

        return data;
    }
}
