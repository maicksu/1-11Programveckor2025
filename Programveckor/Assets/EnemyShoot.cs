using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Reference to the projectile prefab
    public Transform firePoint;         // The position where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile
    public float fireRate = 2f;         // How often the enemy shoots (in seconds)

    private float nextFireTime = 0f;    // Tracks when the enemy can shoot again    
    private Transform player;          // Reference to the player's transform

    void Start()
    {
        // Find the player in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No GameObject with the 'Player' tag found in the scene.");
        }
    }

    void Update()
    {
        // Check if it's time to shoot
        if (player != null && Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + fireRate; // Set the next fire time
        }
    }

    void ShootAtPlayer()
    {
        // Instantiate the projectile at the fire point's position
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Calculate the direction to the player
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Apply velocity to the projectile using its Rigidbody2D
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed; // Shoots toward the player
        }

        // Optional: Destroy the projectile after a certain time to avoid clutter
        Destroy(projectile, 5f);
    }
}
