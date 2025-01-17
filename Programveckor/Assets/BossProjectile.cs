using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public int damage = 10; // Damage dealt to the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile hits the player
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Deal damage to the player
            }

            // Destroy the projectile after hitting the player
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            // Stop the projectile's motion when it hits the ground
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }

            // Destroy the projectile after 2 seconds
            Destroy(gameObject, 2f);
        }
    }
}
