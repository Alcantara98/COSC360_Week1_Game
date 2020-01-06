
using UnityEngine;

public class EnemyWave : MonoBehaviour
{

    // Variable poitning to object prefab
    public Transform alienPrefab;

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
}
