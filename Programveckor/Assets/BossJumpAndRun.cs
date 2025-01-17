using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float walkSpeed = 2f;        // Speed of the boss
    public float jumpForce = 10f;      // How high the boss jumps
    public LayerMask groundLayer;      // Layer for detecting the ground

    private Rigidbody2D rb;            // Rigidbody2D of the boss
    private bool isGrounded;           // Whether the boss is on the ground
    private bool isFacingRight = true; // To determine the direction the boss is facing

    private float actionTimer = 0f;    // Timer to control walking/waiting
    private float jumpTimer = 0f;      // Timer to control jumping
    private int state = 0;             // Current state (0 = forward, 1 = wait, 2 = backward, 3 = wait)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on this GameObject.");
        }
    }

    void Update()
    {
        HandleMovementPattern();
        HandleJumping();
    }

    void HandleMovementPattern()
    {
        actionTimer += Time.deltaTime;

        switch (state)
        {
            case 0: // Walk forward
                Walk(true); // Move right
                if (actionTimer >= 5f)
                {
                    state = 1; // Transition to waiting
                    actionTimer = 0f;
                }
                break;

            case 1: // Wait
                StopMoving();
                if (actionTimer >= 3f)
                {
                    state = 2; // Transition to walking backward
                    actionTimer = 0f;
                }
                break;

            case 2: // Walk backward
                Walk(false); // Move left
                if (actionTimer >= 5f)
                {
                    state = 3; // Transition to waiting
                    actionTimer = 0f;
                }
                break;

            case 3: // Wait
                StopMoving();
                if (actionTimer >= 3f)
                {
                    state = 0; // Transition to walking forward
                    actionTimer = 0f;
                }
                break;
        }
    }

    void HandleJumping()
    {
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= 10f && isGrounded)
        {
            Jump();
            jumpTimer = 0f; // Reset the jump timer
        }
    }

    void Walk(bool forward)
    {
        float direction = forward ? 1 : -1; // Forward is positive, backward is negative
        rb.velocity = new Vector2(direction * walkSpeed, rb.velocity.y);

        // Flip the boss based on the movement direction
        if (forward && !isFacingRight)
        {
            Flip();
        }
        else if (!forward && isFacingRight)
        {
            Flip();
        }
    }

    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y); // Stop horizontal movement
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the boss collides with something tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Boss is grounded
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the boss leaves the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Boss is no longer grounded
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Prevent further jumps until grounded again
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
