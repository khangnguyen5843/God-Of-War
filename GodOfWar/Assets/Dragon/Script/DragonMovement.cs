using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private DragonInput dragonInput;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;


    private void Awake()
    {
        dragonInput = GetComponent<DragonInput>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(dragonInput.horizontalInput * speed, rb.velocity.y);
        if (dragonInput.horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (dragonInput.horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        animator.SetBool("Run", dragonInput.horizontalInput != 0);
        animator.SetBool("Ground", isGrounded);
    }

    private void Jump()
    {
        rb.velocity = new Vector2 (rb.velocity.x, speed);
        animator.SetTrigger("jump");
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
