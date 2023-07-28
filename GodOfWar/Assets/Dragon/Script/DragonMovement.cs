using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D rb;
    private DragonInput dragonInput;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;


    private void Awake()
    {
        dragonInput = GetComponent<DragonInput>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
        animator.SetBool("Run", dragonInput.horizontalInput != 0);
        animator.SetBool("Ground", IsGrounded());
    }

    private void Jump()
    {
        rb.velocity = new Vector2 (rb.velocity.x, speed);
        animator.SetTrigger("jump");
        IsGrounded();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.01f, wallLayer);
        return raycastHit.collider != null;
    }
}
