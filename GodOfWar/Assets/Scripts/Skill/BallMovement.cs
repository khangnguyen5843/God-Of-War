using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;
    private bool isMoving = false;
    private bool canBounceX = true;
    private bool canBounceY = true;
    public bool isActive = true;


    [SerializeField] private SpriteRenderer ball;
    [SerializeField] private Collider2D collider;
    [SerializeField] public int damageBall = 10;


    void Start()
    {
        ShootRandomDirection();
    }

    void Update()
    {
        if (!isActive)
            return;


        if (!isMoving)
            return;

        Vector3 newPosition = (Vector3)direction * speed * Time.deltaTime + transform.position;

        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(newPosition);
        Vector2 newDirection = direction;

        float edgeThreshold = 0.02f;

        if ((viewportPosition.x < edgeThreshold || viewportPosition.x > 1 - edgeThreshold) && canBounceX)
        {
            newDirection.x *= -1;
            canBounceX = false;
        }
        else if (viewportPosition.x > edgeThreshold && viewportPosition.x < 1 - edgeThreshold)
        {
            canBounceX = true;
        }

        if ((viewportPosition.y < edgeThreshold || viewportPosition.y > 1 - edgeThreshold) && canBounceY)
        {
            newDirection.y *= -1;
            canBounceY = false;
        }
        else if (viewportPosition.y > edgeThreshold && viewportPosition.y < 1 - edgeThreshold)
        {
            canBounceY = true;
        }

        direction = newDirection;

        transform.position = newPosition;
    }

    void ShootRandomDirection()
    {
        float angle = Random.Range(0f, 360f);
        direction = Quaternion.Euler(0f, 0f, angle) * Vector2.right;
        isMoving = true;
    }

    public void ToggleObject()
    {
        ball.enabled = true;
        collider.enabled = true;
        isActive = !isActive;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive)
            return;

        if (other.CompareTag("Enemy"))
        {
            MovementEnemySurvival enemy = other.GetComponent<MovementEnemySurvival>();
            if (enemy != null)
            {
                int damageBalle = CharacterStat.Instance.CalculateDamage();
                damageBall = damageBalle;
                enemy.TakeDamage(damageBall);
                Debug.Log("Ball: " + damageBall);
            }
        }

    }
}
