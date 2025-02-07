using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float jumpForce = 7f;
    private Animator animator;
    public bool isGrounded = true;
    private int jumpCount = 0; // Track the number of jumps
    public int maxJumps = 2;   // Maximum number of jumps allowed

    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the GameObject. Please attach a Rigidbody2D component.");
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);

        }
        // Check for jump input and if jumps are available
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps && rb != null)
        {
            Jump();
            animator.SetBool("isJumping", true);
        }
    }

    void Jump()
    {
        print("jump");
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity for consistent jumps
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++; // Increment jump count
        isGrounded = false; // Player is no longer grounded after jumping
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player lands on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count when grounded
        }
    }
}
