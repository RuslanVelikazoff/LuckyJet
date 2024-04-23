using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private const string PLAYER_PREFS_CONTROL = "Control";
    private const string PLAYER_PREFS_EXPERT = "Expert";
    private const string PLAYER_PREFS_CLASSIC = "Classic";

    public static ControlManager Instance;

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

        if (!PlayerPrefs.HasKey(PLAYER_PREFS_CONTROL))
        {
            SetControlClassic();
        }
    }

    public void SetControlExpert()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_CONTROL, PLAYER_PREFS_EXPERT);
    }

    public void SetControlClassic()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_CONTROL, PLAYER_PREFS_CLASSIC);
    }

    public bool IsClassicControl()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_CONTROL) == PLAYER_PREFS_CLASSIC)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
