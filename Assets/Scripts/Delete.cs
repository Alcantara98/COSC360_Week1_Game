using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > 0.5f && GameMaster.playerHealth == 0) 
        {
            GameMaster.playerHealth = 1;
            GameMaster.PlayerHit();
        }
        else if (Time.time - time > 0.6f)
        {
            Destroy(gameObject);
        }
    }
}
