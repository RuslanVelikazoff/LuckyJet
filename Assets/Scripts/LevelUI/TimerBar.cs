using System.Collections;
using TMPro;
using UnityEngine;

public class TimerBar : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI timerText;
    
    private float minute;
    private float seconds;

    private bool startTimer = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);

        if (GamemodeManager.Instance.IsLimitedTimeGamemode())
        {
            this.gameObject.SetActive(true);
            SetTimerInStart();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void SetTimerInStart()
    {
        switch (Data.Instance.GetSelectedMapIndex())
        {
            default:
            case 0:
                minute = 2;
                seconds = 0;
                startTimer = true;
                SetTimerText();
                break;
            case 1:
                minute = 2;
                seconds = 30;
                startTimer = true;
                SetTimerText();
                break;
            case 2:
                minute = 3;
                seconds = 0;
                startTimer = true;
                SetTimerText();
                break;
        }
    }

    private void Update()
    {
        if (startTimer)
        {
            if (seconds <= 0)
            {
                if (minute > 0)
                {
                    minute--;
                    seconds = 60;
                }
                else
                {
                    startTimer = false;
                    GameManager.Instance.LoseGame();
                }
            }
            else
            {
                seconds -= Time.deltaTime;
            }

            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        timerText.text = (int) minute + " : " + (int)seconds;
    }
}
