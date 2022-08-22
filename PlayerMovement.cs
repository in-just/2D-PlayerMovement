using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float checkRadius;

    private float moveDirection;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isJumping = false;
    private float jumpForce = 200f;

    private void Awake()
    {
        // looks for the component this script is attached to
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Inputs();

        AnimateLeftRight();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        Debug.Log(rb.velocity);

        if (isJumping)
        {
            rb.AddForce(transform.up * jumpForce);
            Debug.Log(rb.velocity);
        }
        isJumping = false;
    }

    private void Inputs()
    {
        // horizontal keys (w,d,arrow)
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void AnimateLeftRight()
    {
        if (moveDirection > 0 && !facingRight)
        {
            facingRight = !facingRight; //Inverse bool

            transform.Rotate(0f, 180f, 0f);
        }
        else if (moveDirection < 0 && facingRight)
        {
            facingRight = !facingRight; //Inverse bool

            transform.Rotate(0f, 180f, 0f);
        }
    }

}