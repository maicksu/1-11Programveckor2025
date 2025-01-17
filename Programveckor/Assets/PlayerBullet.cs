using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public Transform firePoint;     // The position where the bullet spawns
    public float bulletSpeed = 20f; // Speed of the bullet
    public float shootCooldown = 0.5f; // Cooldown time between shots (0.5 seconds)

    private Vector2 shootingDirection = Vector2.right; // Default shooting direction (right)
    private float nextShootTime = 0f; // Tracks when the player can shoot again

    private void Start()
    {
        // Ensure the fire point is correctly set
        firePoint = transform;
    }

    void Update()
    {
        // Update shooting direction based on input
        if (Input.GetKey(KeyCode.D))
        {
            shootingDirection = Vector2.right; // Forward
        }
        else if (Input.GetKey(KeyCode.A))
        {
            shootingDirection = Vector2.left; // Backward
        }

        // Check for shooting input and cooldown
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.LeftAlt)) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootCooldown; // Update the next allowed shoot time
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Apply velocity to the bullet using its Rigidbody2D
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootingDirection * bulletSpeed; // Shoots in the current direction
        }

        // Optional: Destroy the bullet after 5 seconds to avoid clutter
        Destroy(bullet, 0.75f);
    }
}
