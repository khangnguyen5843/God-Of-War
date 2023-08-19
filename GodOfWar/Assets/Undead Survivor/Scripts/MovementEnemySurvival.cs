using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemySurvival : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField]
    private float enemySpeed = 1f;
    [SerializeField]
    private Animator enemyAnimator;

    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        playerTransform = MovementPlayerSurvival.playerObj.transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        Vector3 EP = playerTransform.position - transform.position;
        EP.Normalize();
        if (EP.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        enemyAnimator.SetFloat("Speed", EP.magnitude);
        transform.Translate(EP * enemySpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with Player");
        if (collision.tag.Equals("Player"))
        {
            
            Destroy(gameObject);
        }
    }
}
