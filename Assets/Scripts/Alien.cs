using UnityEngine;

public class Alien : MonoBehaviour
{
    //Points the alien is worth
    public int points = 100;
    public GameObject explosion;
    public AudioClip explosionSound = null;

    // When enemy collides with an object with a
    // collider that is a trigger...
    void OnTriggerEnter2D(Collider2D other)
    {
        explosion.transform.localScale = new Vector2(0.1f, 0.1f);
        EnemyWave wave;

        // Check if colliding with the left or right wall
        // (by checking the tags of the collider that the enemy
        //  collided with)
        if (other.tag == "LeftWall")
        {
            // If collided with the left wall, get a reference
            // to the EnemyWave object, which should be a component
            // of enemies parent
            wave = transform.parent.GetComponent<EnemyWave>();
            // Set direction of the wave
            wave.SetDirectionRight();
        }
        else if (other.tag == "RightWall")
        {
            // If collided with the right wall, get a reference
            // to the EnemyWave object, which should be a component
            // of enemies parent
            wave = transform.parent.GetComponent<EnemyWave>();
            // Set direction of the wave
            wave.SetDirectionLeft();
        }
        else if (other.tag == "BottomWall")
        {
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }
            GameMaster.EnemyHit(this, false);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.tag == "Wave")
        {
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }
            GameMaster.EnemyHit(this, false);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }
            GameMaster.EnemyHit(this, false);
            GameMaster.PlayerHit();
            Instantiate(explosion, transform.position, Quaternion.identity);
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
                if (explosionSound != null)
                {
                    AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                }
                // Collided with non enemy projectile (so a player projectile)

                // Destroy the projectile game object
                Destroy(other.gameObject);

                // Report enemy hit to the game master
                GameMaster.EnemyHit(this, true);

                // Destroy self
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                //gameObject.SetActive(false);

            }
        }
    }
}