using UnityEngine;

public class NukeWave: MonoBehaviour
{

    // Variable poitning to object prefab
    public Transform nukePrefab;

    public float changeDirectionProbability;

    public int layerPlus = 0;

    // Speed of the wave movement
    public float speed;

    public int nukeLifePlus = 3;

    // Direction of the wave movement (-ve means left, +ve is right)
    int direction = -1;

    // Use this for initialization
    void Start()
    {
        SetNuke();
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
        if (GameMaster.nukeHealth == 0)
        {
            SetNuke();

            GameMaster.nukeHealth = 10 + nukeLifePlus;
            nukeLifePlus += 3;
            speed += 0.2f;
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

    public void SetNuke()
    {
        direction = -1;

        // Create new game object (from the prefab)
        Transform nuke = Instantiate(nukePrefab);
        nuke.parent = transform;
        // Position the newly created object in the wave
        nuke.localPosition = new Vector3(0, 6, 0);

        transform.position = new Vector3(0, 0, -1);
    }
}
