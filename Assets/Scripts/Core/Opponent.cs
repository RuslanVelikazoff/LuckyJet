using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Opponent : MonoBehaviour
{
    private float speed = 8;
    private float currentDistance = 0;
    private float walkingDistance = .23f;
    private float maxDistance = 2000;

    private int randomSpot;
    
    [SerializeField] 
    private Transform[] moveSpot;

    [SerializeField]
    private OpponentDistanceBar distanceBar;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);

        if (GamemodeManager.Instance.IsCompetitiveGamemode())
        {
            randomSpot = Random.Range(0, moveSpot.Length);
            SetMaxDistance();
            distanceBar.SetSliderInStart(currentDistance, maxDistance);
        }
        else
        {
            this.gameObject.SetActive(false);
            distanceBar.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].localPosition,
            speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot[randomSpot].localPosition) < .2f)
        {
            randomSpot = Random.Range(0, moveSpot.Length);
        }
    }

    private void FixedUpdate()
    {
        currentDistance += walkingDistance;
        distanceBar.SetWalkingDistance(walkingDistance);

        if (currentDistance >= maxDistance)
        {
            GameManager.Instance.LoseGame();
        }
    }

    private void SetMaxDistance()
    {
        switch (Data.Instance.GetSelectedMapIndex())
        {
            case 0:
                maxDistance = 2000;
                break;
            case 1:
                maxDistance = 3000;
                break;
            case 2:
                maxDistance = 4000;
                break;
        }
    }

}
