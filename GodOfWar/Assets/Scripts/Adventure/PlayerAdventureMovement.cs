using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdventureMovement : MonoBehaviour
{
    private GameInput gameInput;
    [SerializeField]
    private float speed = 1f;
    private Vector3 movementDirection;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform checkGroundPoint;
    bool isGrounded = false;
    private Rigidbody2D rigidbody;
    List<Collider2D> batCastDamage = new List<Collider2D>();
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Land"))
        {
            isGrounded= true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !batCastDamage.Contains(collision))
        {
            batCastDamage.Add(collision);
            GetComponent<Health>().ApplyDamage(10);
            StartCoroutine(EndCastDamage());
            
        }
    }
    IEnumerator EndCastDamage()
    {
        yield return new WaitForSeconds(2);
        batCastDamage.Clear();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    public enum CharacterState
    {
        Normal,
        Attack,
        Jump,
        Walk,
        Falling
    }
    private CharacterState currentState;
    private void Awake()
    {
        currentState = CharacterState.Falling;
        gameInput = GetComponent<GameInput>();
        rigidbody = GetComponent<Rigidbody2D>();
        batCastDamage.Clear();
    }

    public void SwitchCharacterState(CharacterState newState)
    {
        // Se duoc chay khi ket thuc trang thai cu
        bool checkFalling = false;
        switch (currentState)
        {
            case CharacterState.Normal: { break; }
            case CharacterState.Attack: { break; }
            case CharacterState.Jump: { break; }
            case CharacterState.Walk: { break; }
            case CharacterState.Falling: {
                    checkFalling = true;
                    break; 
                }
        }
        // Se duoc chay khi bat dau trang thai moi
        switch (newState)
        {
            case CharacterState.Normal:
                {
                    playerAnimator.SetFloat("Speed", 0f);
                    break;
                }
            case CharacterState.Attack: { break; }
            case CharacterState.Jump: {
                    if (!checkFalling)
                    {
                        playerAnimator.SetTrigger("Jump");
                    }
                   
                    break; }
            case CharacterState.Walk:
                {
                    playerAnimator.SetFloat("Speed", 1f);
                    break;
                }
            case CharacterState.Falling: { break; }
        }
        currentState = newState;
    }
    public void SetJumpHeight()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 8);
    }
    public void SetAttack()
    {
        if (gameInput.isMouseDown)
        {
            gameInput.isMouseDown = false;
            SwitchCharacterState(CharacterState.Attack);
            playerAnimator.SetTrigger("IsAttack");
        }
    }
    private void FixedUpdate()
    {
        
        if(isGrounded)
        {
            playerAnimator.SetBool("IsGround", true);
        }
        else
        {
            playerAnimator.SetBool("IsGround", false);

        }
        switch (currentState)
        {
            case CharacterState.Normal:
                {
                    SetAttack();
                    if (gameInput.horizontalInput != 0)
                    {
                        SwitchCharacterState(CharacterState.Walk);
                    }
                    if (isGrounded && gameInput.isJumpBtn)
                    {
                        
                        SwitchCharacterState(CharacterState.Jump);
                    }
                    gameInput.isJumpBtn = false;
                    break;
                }
            case CharacterState.Attack: { break; }
            case CharacterState.Jump: {
                    gameInput.isJumpBtn = false;
                    movementDirection = new Vector3(gameInput.horizontalInput, 0, 0);
                    movementDirection.Normalize();
                    if (movementDirection.magnitude == 0 && currentState == CharacterState.Walk)
                    {
                        SwitchCharacterState(CharacterState.Normal);
                    }
                    break; }
            case CharacterState.Walk:
                {
                    SetAttack();
                    CalculateMovement();
                    break;
                }
            case CharacterState.Falling:
                {
                    CalculateMovement();
                    break;
                }

        }
        gameInput.isMouseDown = false;
    }
    public void StartJumpEnd()
    {
        SwitchCharacterState(CharacterState.Normal);
    }
    void CalculateMovement()
    {
        if (isGrounded && gameInput.isJumpBtn)
        {
            SwitchCharacterState(CharacterState.Jump);
        }
        gameInput.isJumpBtn = false;
        movementDirection = new Vector3(gameInput.horizontalInput, 0, 0);
        movementDirection.Normalize();
        if (movementDirection.magnitude == 0 && currentState == CharacterState.Walk)
        {
            SwitchCharacterState(CharacterState.Normal);
        }
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
}
