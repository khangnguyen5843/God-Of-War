using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFire : MonoBehaviour
{
    [SerializeField] private GameObject circleFire;
    [SerializeField] private SpriteRenderer sphereFire;
    [SerializeField] private Collider2D sphereSphere;
    [SerializeField] private bool isCircleFire;

    [SerializeField] private int damage = 10;

    private void OnEnable()
    {
        isCircleFire = true;
        sphereSphere.enabled = true;
        sphereFire.enabled = true;
    }

    private void OnDisable()
    {
        isCircleFire = false;
        sphereSphere.enabled = false;
        sphereFire.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            MovementEnemySurvival enemy = other.GetComponent<MovementEnemySurvival>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
