using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;    // Speed at which the enemy moves
    private Transform player;      // Reference to the player's position

    void Start()
    {
        // Find the player GameObject by its tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player GameObject has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Move toward the player's position
            Vector2 direction = (player.position - transform.position).normalized; // Get direction to player
            transform.position = new Vector2(transform.position.x + direction.x * moveSpeed * Time.deltaTime,
                                             transform.position.y);
        }
    }
}
