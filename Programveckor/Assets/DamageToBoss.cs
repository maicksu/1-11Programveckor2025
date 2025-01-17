using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;  // Damage value (optional, in case you want to expand functionality)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss1"))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage();  // Call the TakeDamage method on the boss
            }

            // Destroy the projectile after it hits the boss
            Destroy(gameObject);
        }
    }
}
