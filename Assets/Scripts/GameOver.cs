using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Go back to main menu 
            SceneManager.LoadScene("TitleScreen");
        }
    }

    // Display game over message
    void OnGUI()
    {

        // Show player score in white on the top left of the screen
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 30;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, Screen.height / 4f, Screen.width, 70), "Game over");

        string message;

        // Check player's lives left...if more than 0,
        // then player won, otherwise the game was lost   
        // Generate appropriate final message
        if (GameMaster.playerScore < GameMaster.HighestScore)
        {
            // The lost message will be shown in red
            message = "You lost   Score: " + GameMaster.playerScore;
            GUI.color = Color.red;
        }
        else
        {
            // The won message will be shown in white
            message = "New Highest Score!!! You won!!!";
            GUI.color = Color.white;
            GameMaster.HighestScore = GameMaster.playerScore;
        }
        // Show lost/won message
        GUI.Label(new Rect(0, Screen.height / 4f + 50f, Screen.width, 70), message);
        GUI.Label(new Rect(0, Screen.height / 4f + 100f, Screen.width, 70), "Highest Score: " + GameMaster.HighestScore);

        // Last line will be shown in white
        GUI.color = Color.white;
        GUI.Label(new Rect(0, Screen.height / 4f + 240f, Screen.width, 70), "Press Enter to continue...");
    }
}
