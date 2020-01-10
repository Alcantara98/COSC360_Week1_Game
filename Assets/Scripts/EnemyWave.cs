
using UnityEngine;

public class EnemyWave : MonoBehaviour
{

    Transform[] transformsToRotate;

    // Variable poitning to object prefab
    public Transform alienPrefab;

    public float changeDirectionProbability;

    public int layerPlus = 0;

    // Speed of the wave movement
    public float speed = 2;

    // Direction of the wave movement (-ve means left, +ve is right)
    int direction = -1;

    // Use this for initialization
    void Start()
    {
        SetMissiles();
        transformsToRotate = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Generate number a random number between 0 and 1
        float randomSample = Random.Range(0f, 1f);
        // If that random number is less than the 
        // probability of shooting, then try to shoot
        if (randomSample < changeDirectionProbability)
        {
            if(direction == -1)
            {
                SetDirectionRight();
            }
            else if(direction == 1)
            {
                SetDirectionLeft();
            }
        }
        // Move the wave on the horizonatal axis
        transform.Translate(new Vector3(Time.deltaTime * direction * 2.0f, -1 * Time.deltaTime * speed * 0.2f, 0f));
        if(GameMaster.enemyLeft == 1)
        {
            //transform.position = new Vector3(0,0,0);
            SetMissiles();

            //speed += 2;
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
        float gapBetweenAliens = 1.0f;
        float yOffset = 0.0f;
        for (int y = 0; y < 2 + layerPlus; y++)
        {
            // Horizontal offset for every other row
            float offsetX = ((y % 2 == 0) ? 0.0f : 0.5f) * gapBetweenAliens;
            for (int x = -4; x < 4; ++x)
            {
                // Create new game object (from the prefab)
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;
                // Position the newly created object in the wave
                alien.localPosition = new Vector3((x * gapBetweenAliens) + offsetX, 0 + (y * (gapBetweenAliens - 0.5f)) + 4 + yOffset, -1);
                alien.rotation = Quaternion.identity;
                alien.Rotate(0.0f, 0.0f, -210.0f, Space.Self);
                yOffset += 0.1f;
            }
        }
        transform.position = new Vector3(0, 0, -1);
        layerPlus++;
    }
}
