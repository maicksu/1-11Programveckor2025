using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // Amount of damage the bullet deals

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Access the enemy's health system
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Apply damage to the enemy
            }

            // Destroy the bullet after it hits an enemy
            Destroy(gameObject);
        }
    }
}
