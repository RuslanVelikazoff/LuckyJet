using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject boomGameObject;

    public void Death()
    {
        Instantiate(boomGameObject, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        GameManager.Instance.LoseGame();
    }
}
