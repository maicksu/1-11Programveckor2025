using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public Transform firePoint;     // The position where the bullet spawns
    public float bulletSpeed = 20f; // Speed of the bullet

    private void Start()
    {
        firePoint = transform;
    }
    void Update()
    {
        // Shoot when the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
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
            rb.velocity = firePoint.right * bulletSpeed; // Shoots in the fire point's forward direction
        }

        // Optional: Destroy the bullet after 5 seconds to avoid clutter
        Destroy(bullet, 5f);
    }
}
