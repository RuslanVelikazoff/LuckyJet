using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            CoinBar.Instance.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
