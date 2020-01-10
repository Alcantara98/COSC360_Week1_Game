using UnityEngine.SceneManagement;
using UnityEngine;

public class Amo : MonoBehaviour
{

    // When enemy collides with an object with a
    // collider that is a trigger...
    void OnTriggerEnter2D(Collider2D other)
    {
        BonusAmo wave;

        // Check if colliding with the left or right wall
        // (by checking the tags of the collider that the enemy
        //  collided with)
        if (other.tag == "LeftWall")
        {
            wave = transform.parent.GetComponent<BonusAmo>();
            wave.SetDirectionRight();
        }
        else if (other.tag == "RightWall")
        {
            wave = transform.parent.GetComponent<BonusAmo>();
            wave.SetDirectionLeft();
        }
        else if (other.tag == "BottomWall")
        {
            BonusAmo.falling = false;
            Destroy(gameObject);
        }
        else if (other.tag == "Wave")
        {
            BonusAmo.falling = false;
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            Attack.timeToStopDoubleAttack = Time.time;
            Attack.doubleAttack = true;
            Attack.fireCooldownTime = 0.3f;
            BonusAmo.falling = false;
            Destroy(gameObject);
        }
        else
        {
            // Collision with something that is not a wall
            // Check if collided with a projectile
            // A projectile has a Projectile script component,
            // so try to get a reference to that component
            Projectile projectile = other.GetComponent<Projectile>();

            //If that refernce is not null, then check if it's an enemyProjectile      
            if (projectile != null && !projectile.enemyProjectile)
            {
                // Collided with non enemy projectile (so a player projectile)

                // Destroy the projectile game object
                Destroy(other.gameObject);

                BonusAmo.falling = false;
                // Destroy self
                Destroy(gameObject);


            }
        }
    }
}
