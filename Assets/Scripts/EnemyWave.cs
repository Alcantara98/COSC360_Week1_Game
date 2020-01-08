
using UnityEngine;

public class EnemyWave : MonoBehaviour
{

    Transform[] transformsToRotate;

    // Variable poitning to object prefab
    public Transform alienPrefab;

    // Speed of the wave movement
    public float speed = 2;

    // Direction of the wave movement (-ve means left, +ve is right)
    int direction = -1;

    public float amountMovedDown = 0;

    // Use this for initialization
    void Start()
    {
        SetMissiles();
        transformsToRotate = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float sub = Time.deltaTime * speed * 0.2f;
        amountMovedDown += sub;
        // Move the wave on the horizonatal axis
        transform.Translate(new Vector3(Time.deltaTime * direction * 2, -1 * sub, 0));
        if(GameMaster.enemyLeft == 1)
        {
            transform.Translate(new Vector3(0, amountMovedDown, 0));
            amountMovedDown = 0;
            SetMissiles();

            speed++;
            GameMaster.enemyLeft = 0;
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
            transformsToRotate = GetComponentsInChildren<Transform>();
            for (int i = 1; i < transformsToRotate.Length; i++)
            {
                transformsToRotate[i].Rotate(0.0f, 0.0f, -60.0f, Space.Self);
            }
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
            transformsToRotate = GetComponentsInChildren<Transform>();
            for (int i = 1; i < transformsToRotate.Length; i++)
            {
                transformsToRotate[i].Rotate(0.0f, 0.0f, 60.0f, Space.Self);
            }
        }
    }

    public void SetMissiles()
    {
        direction = -1;
        float gapBetweenAliens = 1.5f;

        for (int y = 0; y < 2; y++)
        {
            // Horizontal offset for every other row
            float offsetX = ((y % 2 == 0) ? 0.0f : 0.5f) * gapBetweenAliens;
            for (int x = -3; x < 3; ++x)
            {
                // Create new game object (from the prefab)
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;
                // Position the newly created object in the wave
                alien.localPosition = new Vector3((x * gapBetweenAliens) + offsetX, 0 + (y * gapBetweenAliens) + 4, 0);
                alien.rotation = Quaternion.identity;
                alien.Rotate(0.0f, 0.0f, -210.0f, Space.Self);
            }
        }
    }
}
