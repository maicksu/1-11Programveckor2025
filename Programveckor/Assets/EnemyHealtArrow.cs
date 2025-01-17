using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 10; // Enemy's total health

    public void TakeDamage(int damage)
    {
        health -= damage; // Reduce health by the damage amount

        if (health <= 0)
        {
            Die(); // Call the die method if health is depleted
        }
    }

    void Die()
    {
        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
