using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void Die()
    {
        ReSpawn();
    }

    public void ReSpawn()
    {
        transform.position = spawnPoint;
    }
}
