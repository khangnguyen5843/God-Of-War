using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSurvival : MonoBehaviour
{
    private Vector2 moveDir;
    private float bulletSpeed = 20f;
    [SerializeField] private int damage = 10;
    
    void Start()
    {
        Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos.z = 0f;
        moveDir = playerPos - transform.position;
        moveDir.Normalize();
        if(moveDir.x> 0)
        {
            float angle = Vector3.Angle(moveDir, Vector3.up);

            transform.Rotate(new Vector3(0, 0, -angle));

        }
        else
        {
            float angle = Vector3.Angle(moveDir, Vector3.up);

            transform.Rotate(new Vector3(0, 0, angle));

        }
    }
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            MovementEnemySurvival enwmy = collision.GetComponent<MovementEnemySurvival>();
            if(enwmy != null)
            {
                enwmy.TakeDamage(damage);
            }
            Destroy(gameObject);         
        }
    }
}
