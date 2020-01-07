/*
	Created by: Lech Szymanski
				lechszym@cs.otago.ac.nz
				Oct 30, 2015			
*/

using UnityEngine;

public class Player : MonoBehaviour {

	// Private variables (not visible in the Inspector panel)
	// The speed of player movement
	float speed = 10;

    // Flag indicating whether the player is at the 
    // left edge of the screen
    bool atLeftWall = false;

    // Flag indicating whether the player is at the 
    // right edge of the screen
    bool atRightWall = false;

    // On collision with a trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        if (other.tag == "LeftWall")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            atLeftWall = true;
        }
        else if (other.tag == "RightWall")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atRightWall = true;
        }
        else
        {
            // Collision with something that is not a wall
            // Check if collided with a projectile
            // A projectile has a Projectile script component,
            // so try to get a reference to that component
            Projectile projectile = other.GetComponent<Projectile>();

            //If that refernce is not null, then check if it's an enemyProjectile      
            if (projectile != null && projectile.enemyProjectile)
            {
                // Collided with an enemy projectile

                // Destroy the projectile game object
                Destroy(other.gameObject);

                // Report player hit to the game master
                GameMaster.PlayerHit();

                // Destroy self
                Destroy(gameObject);
            }
        }
    }

    // When no longer colliding with an object...
    void OnTriggerExit2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has ceased to collide with
        if (other.tag == "LeftWall")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            atLeftWall = false;
        }
        else if (other.tag == "RightWall")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atRightWall = false;
        }
    }

    // When player collides with an object that is
    // not a trigger...
    void OnCollisionEnter2D(Collision2D other)
    {
        // If the other object is tagged as "Player"...
        if (other.gameObject.tag == "Enemy")
        {

            // Report player hit to the game master
            GameMaster.PlayerHit();

            // Destroy the Player game object
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float movementInput = Input.GetAxis("Horizontal");

        // If close to wall and moving towards it,
        // stop the movment
        if (atLeftWall && (movementInput < 0))
        {
            movementInput = 0;
        }
        if (atRightWall && (movementInput > 0))
        {
            movementInput = 0;
        }

        // Move the player object
        transform.Translate( new Vector3(Time.deltaTime * speed * movementInput,0,0), Space.World);

        if (Input.GetButton("Jump"))
        {
            // Get player's attack component
            // and execute its Shoot() method
            Attack attack = GetComponent<Attack>();
            attack.Shoot();
        }
    }
}