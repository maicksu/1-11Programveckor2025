using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private int damage = 10; // Damage dealt to the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile hits the player
        if (collision.CompareTag("Player"))
        {
            // Access the PlayerHealth component on the player and deal damage
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Apply damage
            }

            // Destroy the projectile after hitting the player
            Destroy(gameObject);
        }
    }
}
