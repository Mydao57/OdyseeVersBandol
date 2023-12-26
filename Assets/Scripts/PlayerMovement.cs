using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private float dirX = 0f;
    private float dirY = 0f;

    private enum MovementState {idle, running};

    [SerializeField] private float moveSpeed = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(dirX, dirY).normalized; // Normalize to ensure consistent movement speed in all directions

        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (dirY > 0f) {
            state = MovementState.running;
        }
        else if (dirY < 0f) {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        animator.SetInteger("state", (int)state);
    }

}
