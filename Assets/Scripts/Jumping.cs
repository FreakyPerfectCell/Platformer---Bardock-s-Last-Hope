using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 10f; // The force with which the player will jump
    private bool isJumping = false; // Tracks if the player is in the air
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Animator animator; // Reference to the Animator component

    public LayerMask groundLayer; // Ground layer to check if the player is grounded

    void Start()
    {
        // Get the Rigidbody2D and Animator components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null || animator == null)
        {
            Debug.LogError("Rigidbody2D or Animator component is missing!");
        }
    }

    void Update()
    {
        // Check if the player is grounded
        bool isGrounded = IsGrounded();

        // Handle jumping input (W key)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        // Update animations
        if (isGrounded && !isJumping)
        {
            animator.Play("Idle"); // Switch to Idle when on the ground
        }
        else if (!isGrounded && isJumping)
        {
            animator.Play("Jump"); // Switch to Jump animation while in the air
        }
    }

    // Function to check if the player is grounded
    private bool IsGrounded()
    {
        // Perform a raycast downwards to check if the player is grounded
        return Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.1f, 0), 0.2f, groundLayer);
    }

    // Function to make the player jump
    private void Jump()
    {
        // Apply an upward force to the Rigidbody2D to make the player jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
    }

    // This function will be called when the player lands
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) // If the player hits the ground
        {
            isJumping = false;
        }
    }
}