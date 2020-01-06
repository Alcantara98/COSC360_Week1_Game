
using UnityEngine;

public class EnemyWave : MonoBehaviour
{

    // Variable poitning to object prefab
    public Transform alienPrefab;

    // Speed of the wave movement
    public float speed;

    // Direction of the wave movement (-ve means left, +ve is right)
    int direction = -1;

    // Use this for initialization
    void Start()
    {
        float gapBetweenAliens = 1.5f;

        for (int y = 0; y < 4; y++)
        {
            // Horizontal offset for every other row
            float offsetX = ((y % 2 == 0) ? 0.0f : 0.5f) * gapBetweenAliens;
            for (int x = -3; x < 3; ++x)
            {
                // Create new game object (from the prefab)
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;
                // Position the newly created object in the wave
                alien.localPosition = new Vector3((x * gapBetweenAliens) + offsetX, 0 + (y * gapBetweenAliens), 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the wave on the horisonatal axis
        transform.Translate(new Vector3(Time.deltaTime * direction * speed, 0, 0));
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
            transform.Translate(new Vector3(0, -0.5f, 0));
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
            transform.Translate(new Vector3(0, -0.5f, 0));
        }
    }
}
