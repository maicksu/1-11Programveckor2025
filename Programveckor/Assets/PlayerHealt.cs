using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;   // Maximum health of the player
    public int currentHealth;     // Current health of the player

    void Start()
    {
        currentHealth = maxHealth; // Initialize the player's health
        Debug.Log("Player Health: " + currentHealth); // Display initial health in the console
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;   // Decrease health by the damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent health from going below 0
        Debug.Log("Player Health: " + currentHealth); // Display updated health in the console

        if (currentHealth <= 0)
        {
            Die(); // Handle the player's death
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // Handle death logic here (e.g., restart level, game over screen)
    }
}
