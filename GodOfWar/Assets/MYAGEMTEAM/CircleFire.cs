using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFire : MonoBehaviour
{
    [SerializeField] private GameObject circleFire;
    [SerializeField] private SpriteRenderer sphereFire;
    [SerializeField] private Collider2D sphereSphere;
    [SerializeField] private bool isCircleFire;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            /*Destroy(gameObject);*/
           /* Destroy(collision.gameObject);*/
        }
    }
}
