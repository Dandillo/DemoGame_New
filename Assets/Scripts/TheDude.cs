using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDude : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 2.2f;
    private bool isGrounded = false;
    private bool facingRight = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Run()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
            if ((!facingRight && Input.GetAxis("Horizontal") > 0) 
                || (facingRight && Input.GetAxis("Horizontal") < 0))
                Flip();
        }
        if (isGrounded && Input.GetButton("Jump"))
            Jump();
    }
}
