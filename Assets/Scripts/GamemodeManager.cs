using UnityEngine;

public class GamemodeManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SELECTED_GAMEMODE = "Gamemode";
    private const string PLAYER_PREFS_COMPETITIVE = "CompetitiveMode";
    private const string PLAYER_PREFS_SINGLE = "SingleMode";
    private const string PLAYER_PREFST_LIMITED_TIME = "LimitedTimeMode";

    public static GamemodeManager Instance;

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

    public void SelectCompetitiveGamemode()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_SELECTED_GAMEMODE, PLAYER_PREFS_COMPETITIVE);
    }

    public void SelectedSingleGamemode()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_SELECTED_GAMEMODE, PLAYER_PREFS_COMPETITIVE);
    }

    public void SelectedLimitedTimeGamemode()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_SELECTED_GAMEMODE, PLAYER_PREFST_LIMITED_TIME);
    }

    public bool IsCompetitiveGamemode()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_SELECTED_GAMEMODE) == PLAYER_PREFS_COMPETITIVE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool IsSingleGamemode()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_SELECTED_GAMEMODE) == PLAYER_PREFS_SINGLE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool IsLimitedTimeGamemode()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_SELECTED_GAMEMODE) == PLAYER_PREFST_LIMITED_TIME)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
