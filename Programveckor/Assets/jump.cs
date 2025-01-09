using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump2DSidescroller : MonoBehaviour
{
    public float jumpForce = 5f; // Force applied for jumping
    public LayerMask groundLayer; // Layer to detect ground
    public Transform groundCheck; // Reference to ground check point
    public float groundCheckRadius = 0.2f; // Radius for ground check

    private Rigidbody2D rb;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Apply jump force
    }

    void OnDrawGizmos()
    {
        // Visualize the ground check circle in the editor
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
