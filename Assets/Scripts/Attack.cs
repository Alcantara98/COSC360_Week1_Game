﻿using UnityEngine;
//done
public class Attack : MonoBehaviour
{
    public static bool doubleAttack = false;
    // Variable storing projectile object
    // prefab
    public Transform shotPrefab;
    public Transform shotPrefab2;
    public float doubleAttackTimeLimit;
    public static float timeToStopDoubleAttack;

    // Probability of auto-shoot (0 if
    // no autoshoot)
    public float autoShootProbability;

    // Cooldown time for firing
    public static float fireCooldownTime = 0.4f;

    // How much time is left until able to fire again 
    float fireCooldownTimeLeft = 0.8f;

    // Variable storing a reference to an audio clip
    public AudioClip shotSound = null;

    // Per every frame...
    void Update()
    {
        // If still some time left until can fire again
        // reduce the time by the time since last
        // frame 
        if (fireCooldownTimeLeft > 0)
        {
            fireCooldownTimeLeft -= Time.fixedDeltaTime;
        }

        // If auto-shoot probability is more than zero...
        if (autoShootProbability > 0)
        {
            // Generate number a random number between 0 and 1
            float randomSample = Random.Range(0f, 1f);
            // If that random number is less than the 
            // probability of shooting, then try to shoot
            if (randomSample < autoShootProbability)
            {
                Shoot();
            }
        }
    }

    // Method for firing a projectile
    public void Shoot()
    {
        if (Time.time - timeToStopDoubleAttack > doubleAttackTimeLimit)
        {
            doubleAttack = false;
            fireCooldownTime = 0.4f;
        }
        // Shoot only if the fire cooldown period
        // has expired
        if (fireCooldownTimeLeft <= 0)
        {
            // Create a projectile object from 
            // the shot prefab
            Transform shot = Instantiate(shotPrefab);
            // Set the position of the projectile object
            // to the position of the firing game object
            shot.position = transform.position - new Vector3(0.115f, 0, 0); ;
            // Set time left until next shot
            // to the cooldown time
            fireCooldownTimeLeft = fireCooldownTime;

            if(doubleAttack == true)
            {
                // Create a projectile object from 
                // the shot prefab
                Transform shot2 = Instantiate(shotPrefab2);
                // Set the position of the projectile object
                // to the position of the firing game object
                shot2.position = transform.position - new Vector3(2.18f, 0, 0);
            }

            // Check if shotSound variable has been set...if yes,
            // then play it
            if (shotSound != null)
            {
                AudioSource.PlayClipAtPoint(shotSound, transform.position);
            }
        }
    }
}
