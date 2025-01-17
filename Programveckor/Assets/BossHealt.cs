using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int maxHits = 50;  // Number of hits the boss can take
    private int currentHits = 0;  // Tracks how many hits the boss has taken

    public void TakeDamage()
    {
        currentHits++;  // Increment the hit counter
        Debug.Log("Boss took damage! Hits: " + currentHits);

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss has been defeated!");
        Destroy(gameObject);  // Destroy the boss GameObject
    }
}
