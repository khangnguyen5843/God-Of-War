// LightningStrike.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public GameObject lightningPrefab; // Assign the lightning effect prefab in the Inspector
    public float strikeCooldown = 5f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= strikeCooldown)
        {
            timer = 0f;
            StrikeRandomEnemy();
        }
    }

    private void StrikeRandomEnemy()
    {
        List<GameObject> enemies = EnemyManager.instance.GetEnemyList();

        if (enemies.Count > 0)
        {
            int randomIndex = Random.Range(0, enemies.Count);
            GameObject randomEnemy = enemies[randomIndex];

            // Create a lightning effect at the enemy's position
            Instantiate(lightningPrefab, randomEnemy.transform.position, Quaternion.identity);
        }
    }
}
