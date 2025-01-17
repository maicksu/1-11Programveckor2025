using UnityEngine;

public class BossStompDamage : MonoBehaviour
{
    public int stompDamage = 20;         // Damage dealt when the boss lands on the player
    public LayerMask playerLayer;        // Layer to identify the player

    private bool isFalling = false;      // Tracks if the boss is falling

    void Update()
    {
        // Check if the boss is falling
        isFalling = GetComponent<Rigidbody2D>().velocity.y < 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the boss is falling and collides with the player
        if (isFalling && collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(stompDamage);
                Debug.Log("Player took " + stompDamage + " damage from boss stomp.");
            }
        }
    }
}
