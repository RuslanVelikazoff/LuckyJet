using UnityEngine;
using UnityEngine.UI;

public class BackgroundImage : MonoBehaviour
{
    private const string PLAYER_PREFS_TIME = "TimeOfDay";
    private const string PLAYER_PREFS_DAY = "Day";
    private const string PLAYER_PREFS_NIGHT = "Night";
    
    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private Sprite nightSprite;
    [SerializeField] 
    private Sprite daySprite;

    public static BackgroundImage Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey(PLAYER_PREFS_TIME))
        {
            if (IsNigh())
            {
                SetNightSprite();
            }
            else
            {
                SetDaySprite();
            }
        }
        else
        {
            SetNightSprite();
        }
    }

    public bool IsNigh()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_TIME) == PLAYER_PREFS_NIGHT)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetNightSprite()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_TIME, PLAYER_PREFS_NIGHT);
        backgroundImage.sprite = nightSprite;
    }

    public void SetDaySprite()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_TIME, PLAYER_PREFS_DAY);
        backgroundImage.sprite = daySprite;
    }
}
