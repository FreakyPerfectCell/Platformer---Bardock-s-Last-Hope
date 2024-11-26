using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("No Animator component found on the player.");
        }
    }

    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if (isMoving)
        {
            animator.Play("Fly");

            if (Input.GetKey(KeyCode.A))
            {
                FaceDirection(-1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                FaceDirection(1);
            }
        }
        else
        {
            animator.Play("Idle");
        }
    }

    private void FaceDirection(int direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }
}