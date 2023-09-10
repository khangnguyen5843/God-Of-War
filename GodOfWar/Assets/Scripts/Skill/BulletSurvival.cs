using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSurvival : MonoBehaviour
{
    private Vector2 moveDir;
    private float bulletSpeed = 20f;
    private int damage;
    private CharacterStat characterStat;

    void Start()
    {
        Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos.z = 0f;
        moveDir = playerPos - transform.position;
        moveDir.Normalize();
        if (moveDir.x > 0)
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

    public void SetCharacterStat(CharacterStat stat)
    {
        characterStat = stat;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            MovementEnemySurvival enemy = collision.GetComponent<MovementEnemySurvival>();
            if (enemy != null)
            {
                // Truy cập CharacterStat thông qua Singleton
                int damage = CharacterStat.Instance.CalculateDamage();
                enemy.TakeDamage(damage);
                Debug.Log(damage);
            }
            Destroy(gameObject);
        }
    }
}
