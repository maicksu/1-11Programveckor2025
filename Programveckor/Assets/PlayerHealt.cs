using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;   // Maximum health of the player
    public int currentHealth;     // Current health of the player

    void Start()
    {
        currentHealth = maxHealth; // Initialize player's health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease health by damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0

        Debug.Log("Player took damage. Current health: " + currentHealth);

        // Check if the player has died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Increase health by heal amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't exceed max
        Debug.Log("Player healed. Current health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Player died!"); // Handle death
        print("Player Dead");
    }
}
