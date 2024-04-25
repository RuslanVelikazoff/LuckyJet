using System.Collections;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private IEnumerator Start()
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(.11f);
        this.gameObject.SetActive(false);
    }
}
