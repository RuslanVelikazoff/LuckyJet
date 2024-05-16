using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolicyControl : MonoBehaviour
{
    public SpashScreenLoader loader;
    public UniWebView policyWebView;
    public string policyUrl;
    public GameObject noConnectionScreen; // UI для сообщения об отсутствии интернета
    public GameObject loadingScreen;
    public GameObject backgroundForPolicy, backgroundForOther; // Отдельные фоны для разных сценариев
 
    private bool pageLoadCompleteHandled = false; // Флаг для отслеживания выполнения OnPolicyPageLoadComplete
 
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        CheckInitialConnection();
    }
 
    private void CheckInitialConnection()
    {
        // Проверяем наличие интернет-соединения при старте
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingScreen.SetActive(false);
            noConnectionScreen.SetActive(true);
        }
        else
        {
            NavigateBasedOnPolicyCheck();
        }
    }
 
    private IEnumerator CheckConnectionAndProceed()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingScreen.SetActive(false);
            noConnectionScreen.SetActive(true);
            yield return new WaitForSeconds(5f);
        }
 
        noConnectionScreen.SetActive(false);
        loadingScreen.SetActive(true);
        DisplayPolicyPage();
    }
 
    private void DisplayPolicyPage()
    {
        policyWebView.OnPageFinished += OnPolicyPageLoadComplete; // Подписываемся на событие завершения загрузки страницы
        policyWebView.Load(policyUrl);
    }
 
    private void OnPolicyPageLoadComplete(UniWebView webView, int statusCode, string currentUrl)
    {
        if (pageLoadCompleteHandled) return; // Предотвращаем повторное выполнение метода
 
        UpdateUIBasedOnUrl(currentUrl);
        policyWebView.Show();
 
        if (policyUrl != currentUrl)
        {
            Destroy(gameObject);
        }
 
        pageLoadCompleteHandled = true; // Устанавливаем флаг, указывая, что метод выполнен
    }
 
    private void UpdateUIBasedOnUrl(string currentUrl)
    {
        bool isPolP = currentUrl == policyUrl;
        GameObject activeBackground = isPolP ? backgroundForPolicy : backgroundForOther;
        activeBackground.SetActive(true);
        Screen.orientation = isPolP ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyCheck", isPolP ? "Confirmed" : currentUrl);
    }
 
    public void ConfirmPolicy()
    {
        NavigateBasedOnPolicyCheck();
    }
 
    private void NavigateBasedOnPolicyCheck()
    {
        if (PlayerPrefs.GetString("PolicyCheck", "") == "")
        {
            StartCoroutine(CheckConnectionAndProceed());
        }
        else
        {
            string policyCheck = PlayerPrefs.GetString("PolicyCheck", "");
            if (policyCheck == "Confirmed")
            {
                loader.load = true;
            }
            else
            {
                policyWebView.Load(policyCheck);
                policyWebView.Show();
                backgroundForOther.SetActive(true);
            }
        }
    }
}
