using UnityEngine;

public class Fuel : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerFuel>().AddFuel();
            Destroy(this.gameObject);
        }
    }
}
