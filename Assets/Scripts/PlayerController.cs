using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float movementSpeed = 5.0f;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputHandler();
    }

    void FixedUpdate()
    {
        move();
    }

    void inputHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void move()
    {
        rb.velocity = new Vector2(moveDir.x * movementSpeed, moveDir.y * movementSpeed);
    }

    // Update is called once per frame

}
