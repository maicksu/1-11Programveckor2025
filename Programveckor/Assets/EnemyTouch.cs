using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damagePerSecond = 5; // Damage dealt per second
    public float damageInterval = 1f; // Time interval between each damage application
    private float nextDamageTime = 0f; // Timer for damage application

    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the enemy is touching the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // If enough time has passed, deal damage to the player
            if (Time.time >= nextDamageTime)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damagePerSecond); // Apply damage
                    nextDamageTime = Time.time + damageInterval; // Reset the timer
                }
            }
        }
    }
}
