using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null || animator == null)
        {
            Debug.LogError("No Rigidbody2D or Animator component found on the player.");
        }
    }

    void Update()
    {
        movement.x = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Jump();
        }

        HandleAnimations();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    private void HandleAnimations()
    {
        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            if (movement.x != 0)
            {
                animator.Play("Walk");
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.1f, 0), 0.2f, groundLayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}