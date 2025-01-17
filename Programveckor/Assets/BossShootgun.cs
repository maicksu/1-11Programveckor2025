using UnityEngine;

public class BossShotgunShoot : MonoBehaviour
{
    public GameObject projectilePrefab;   // The projectile prefab to shoot
    public Transform firePoint;           // The point where the projectiles spawn
    public float projectileSpeed = 10f;   // Speed of the projectiles
    public float fireRate = 3f;           // Fire every 3 seconds
    public float spreadAngle = 15f;       // Angle between projectiles in the shotgun pattern
    private float nextFireTime = 0f;      // Tracks when the boss can shoot again

    private Transform player;             // Reference to the player

    void Start()
    {
        // Find the player by tag (ensure your player GameObject is tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the Player is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootShotgunAtPlayer();
            nextFireTime = Time.time + fireRate; // Reset the cooldown
        }
    }

    void ShootShotgunAtPlayer()
    {
        if (player == null) return; // Safety check if player is null

        // Calculate direction to the player
        Vector2 directionToPlayer = (player.position - firePoint.position).normalized;

        // Calculate the base angle toward the player
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Fire three projectiles in a shotgun pattern
        for (int i = -1; i <= 1; i++) // -1, 0, 1 for three projectiles
        {
            float angleOffset = i * spreadAngle; // Adjust for shotgun spread
            FireProjectile(baseAngle + angleOffset);
        }
    }

    void FireProjectile(float angle)
    {
        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Rotate the projectile
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Apply velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            rb.velocity = direction * projectileSpeed;
        }

        // Destroy the projectile after 5 seconds to prevent clutter
        Destroy(projectile, 5f);
    }
}
