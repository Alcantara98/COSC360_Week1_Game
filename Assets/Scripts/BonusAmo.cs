using UnityEngine;

public class BonusAmo : MonoBehaviour
{

    // Variable poitning to object prefab
    public Transform amoPrefab;

    public static bool falling = false;

    public float spawnProbability;

    public float changeDirectionProbability;

    // Speed of the wave movement
    public float speed;

    // Direction of the wave movement (-ve means left, +ve is right)
    int direction = -1;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {

        float randomDirection = Random.Range(0f, 1f);
        float randomSpawn = Random.Range(0f, 1f);

        if (randomDirection < changeDirectionProbability)
        {
            if (direction == -1)
            {
                SetDirectionRight();
            }
            else if (direction == 1)
            {
                SetDirectionLeft();
            }
        }
        // Move the wave on the horizonatal axis
        transform.Translate(new Vector3(Time.deltaTime * direction * 0.5f, -1 * Time.deltaTime * speed * 0.2f, 0f));
        if (randomDirection < spawnProbability && falling == false)
        {
            SetAmo();
            falling = true;
        }
    }

    // Method for changing wave direction (to be invoked
    // from a collider)
    public void SetDirectionLeft()
    {
        // Check if the current direction is to the right
        if (direction == 1)
        {
            // Changing the direction
            // push the wave down a bit as well
            direction = -1;
        }
    }

    // Method for changing wave direction (to be invoked
    // from a collider)
    public void SetDirectionRight()
    {
        // Check if the current direction is to the left
        if (direction == -1)
        {
            // Changing the direction
            // push the wave down a bit as well
            direction = 1;
        }
    }

    public void SetAmo()
    {
        direction = -1;

        // Create new game object (from the prefab)
        Transform nuke = Instantiate(amoPrefab);
        nuke.parent = transform;
        // Position the newly created object in the wave
        nuke.localPosition = new Vector3(0, 4, 0);

        transform.position = new Vector3(0, 0, -1);
    }
}
