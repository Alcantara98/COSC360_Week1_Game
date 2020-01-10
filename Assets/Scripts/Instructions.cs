using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            // Start the new game

            // Reset the player lives and
            // score
            GameMaster.playerHealth = 10;
            GameMaster.playerScore = 0;
            // Load the first level
            SceneManager.LoadScene("Level1");
        }
    }
}
