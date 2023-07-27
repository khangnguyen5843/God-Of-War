using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementPlayer : MonoBehaviour
{
    public static GameObject playerObj;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Animator animator;
    [SerializeField]

    UnityAction<bool> Dead;
    private SpriteRenderer spriteRenderer;

    private PlayerInput input;
    Vector3 movementDirection;

    void SetAnimationDead(bool isDead)
    {
        animator.SetBool("IsDead", isDead);    
    }
    private void Awake()
    {
        playerObj = gameObject;
        input = GetComponent<PlayerInput>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Dead += SetAnimationDead;
    }
    void Update()
    {
        movementDirection.Set(input.horizontalInput, input.verticalInput, 0f);
        movementDirection.Normalize();
        animator.SetFloat("Speed", movementDirection.magnitude);
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        if(input.horizontalInput > 0) spriteRenderer.flipX = false;
        if(input.horizontalInput < 0) spriteRenderer.flipX = true;
    }
}
