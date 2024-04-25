using UnityEngine;

public class TemplateMove : MonoBehaviour
{
    private Transform destroyVector;
    private Transform spawnVector;

    private float speed;

    private bool newSpawn = false;

    public void SpawnTemplate(float speed, Transform destroyVector, Transform spawnVector)
    {
        this.speed = speed;
        this.destroyVector = destroyVector;
        this.spawnVector = spawnVector;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            destroyVector.localPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, spawnVector.localPosition) < .2f && !newSpawn)
        {
            newSpawn = true;
            TemplateSpawner.Instance.SpawnTemplate();
        }

        if (Vector2.Distance(transform.position, destroyVector.localPosition) < .2f)
        {
            Destroy(this.gameObject);
        }
    }
}
