using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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
            SceneManager.LoadScene("Instructions");
        }
    }

    // Display main menu message
    /*void OnGUI()
    {
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 10;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, 90, Screen.width, Screen.height), "Press any key to start");
    }
    */
}
