using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlate : TargetingTower
{
    public float damagePerSecond = 10;
    [SerializeField] AudioSource sound;
    private bool isSoundPlaying = false;

    void Update()
    {
        // If we have any targets:
        if (targeter.TargetsAreAvailable)
        {
            // Loop through them:
            for (int i = 0; i < targeter.enemies.Count; i++)
            {
                Enemy enemy = targeter.enemies[i];
                // Only burn ground enemies:
                if (enemy is GroundEnemy)
                {
                    enemy.TakeDamage(damagePerSecond * Time.deltaTime);

                    // Check if the sound is not already playing:
                    if (!isSoundPlaying)
                    {
                        sound.Play();
                        isSoundPlaying = true;
                    }
                }
            }
        }
        else
        {
            // No enemies, stop the sound:
            if (isSoundPlaying)
            {
                sound.Stop();
                isSoundPlaying = false;
            }
        }
    }
}
