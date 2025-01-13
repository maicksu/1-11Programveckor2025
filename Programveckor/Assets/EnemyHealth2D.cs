using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth2D : MonoBehaviour
{
    public int maxHealth = 5; // Number of hearts (max health)
    private int currentHealth;
    public GameObject[] hearts;  // Array to hold heart images (filled/empty)
    public Sprite fullHeart;     // Full heart sprite
    public Sprite emptyHeart;    // Empty heart sprite

    void Start()
    {
        currentHealth = maxHealth;

        // Set up heart indicators
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHearts();  // Update the hearts after damage
        Debug.Log(name + " took " + damage + " damage. Remaining health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart; // Set to full heart
            }
            else
            {
                hearts[i].GetComponent<Image>().sprite = emptyHeart; // Set to empty heart
            }
        }
    }

    void Die()
    {
        Debug.Log(name + " died!");

        // Add optional effects before destroying the enemy (like a death animation or sound)

        Destroy(gameObject); // Remove the enemy from the scene
    }
}
