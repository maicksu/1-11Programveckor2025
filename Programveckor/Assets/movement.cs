using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    Animator PlayWalk;
    private float moveInput;
    void Start()
    {
        PlayWalk = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        HandleMovement();
        UpdateAnimations();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        // Flip character based on movement direction
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }

        // Set walking animation
        animator.SetBool("isWalking", moveInput != 0);
        animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
    }

   

    void UpdateAnimations()
    {


        // Check if grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);

        }

        // Set animation states
        animator.SetBool("isWalking", moveInput != 0 && isGrounded);
    }
}

