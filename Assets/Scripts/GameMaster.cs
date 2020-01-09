using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // Static variables - there's only one instance
    // of this variable for the entire game
    public static int enemyLeft = 0;
    // Player health - always start with 3 lives
    public static int playerHealth = 1000;
    // Player score
    public static int playerScore = 0;

    // Method to call when enemy is hit
    public static void EnemyHit(Alien alien)
    {
        // Add enemy points to player's score
        playerScore += alien.points;

        // Get the reference to alien's parent, the wave object
        Transform enemyWave = alien.transform.parent;

        // Get an array of references to all children of the wave game object
        // who have an Alien component (so, we're looking for all the
        // aliens remaining in the wave)
        Component[] aliensLeft = enemyWave.GetComponentsInChildren<Alien>();

        //Updates Enemy Left
        enemyLeft = aliensLeft.Length;
        // If only one alien is left, that's the alien that just has been
        // hit and is about to be deleted...so no more aliens will be left
        //if (aliensLeft.Length == 1)
        //{
            //SceneManager.LoadScene("GameOver");
           // enemyLeft = 1;
        //}
        
    }

    // Method to call when player is hit
    public static void PlayerHit()
    {
        playerHealth--;
        // Reduce player's lives
        if (playerHealth == 0)
        {
            //No more lives left, load the GameOver scene
            SceneManager.LoadScene("GameOver");
        }
    }
}