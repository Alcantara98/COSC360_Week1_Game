using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float WaveSpeed;
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the wave on the horizonatal axis
        transform.Translate(new Vector3(Time.deltaTime * direction * WaveSpeed, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RightWall")
        {
            direction = -1;
        }
        else if (other.tag == "LeftWall")
        {
            direction = 1;
        }
    }
}
