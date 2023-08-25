using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        idle,
        walk,
        run,
        attack
    }

    public enum PlayerFacing
    {
        up,
        down,
        left,
        right,
    }

    public PlayerFacing facing;

    public PlayerState currentState;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Vector2 velocity;

    public Animator animator;

    // make reference to 
    void Start()
    {
        moveSpeed = 5f;
        currentState = PlayerState.walk;
        velocity = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerState.walk)
        {
            UpdateAnimation();
        }

        velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }

    void UpdateAnimation()
    {
        if (velocity != Vector2.zero)
        {
            UpdateMovement();

            animator.SetBool("Running", true);
            animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }


    void UpdateMovement()
    {
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }
}
