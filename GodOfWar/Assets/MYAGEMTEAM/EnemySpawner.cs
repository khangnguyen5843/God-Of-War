using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnInterval = 1.0f;
    public float minSpawnDistance = 1.0f; // Minimum distance from the camera's edges
    public float monsterSize = 1.0f; // Adjust this based on your monster's size
    private float timer = 0.0f;

    private Camera mainCamera;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0.0f;
            SpawnEnemyAtCameraEdge();
        }
    }

    private void SpawnEnemyAtCameraEdge()
    {
        Vector3 spawnPosition = GetSpawnPositionAtCameraEdge();
        int rand = Random.Range(0, enemyPrefab.Length);

        GameObject enemy = Instantiate(enemyPrefab[rand], spawnPosition, Quaternion.identity);
        spawnedEnemies.Add(enemy);
    }

    private Vector3 GetSpawnPositionAtCameraEdge()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        // Randomly choose an edge (0 to 3) for spawning
        int edgeIndex = Random.Range(0, 4);

        float spawnX = 0f;
        float spawnY = 0f;

        switch (edgeIndex)
        {
            case 0: // Top edge
                spawnY = halfHeight + minSpawnDistance + monsterSize * 0.5f;
                spawnX = Random.Range(-halfWidth, halfWidth);
                break;
            case 1: // Bottom edge
                spawnY = -halfHeight - minSpawnDistance - monsterSize * 0.5f;
                spawnX = Random.Range(-halfWidth, halfWidth);
                break;
            case 2: // Left edge
                spawnX = -halfWidth - minSpawnDistance - monsterSize * 0.5f;
                spawnY = Random.Range(-halfHeight, halfHeight);
                break;
            case 3: // Right edge
                spawnX = halfWidth + minSpawnDistance + monsterSize * 0.5f;
                spawnY = Random.Range(-halfHeight, halfHeight);
                break;
        }

        // Calculate the spawn position based on camera position and edge coordinates
        Vector3 spawnPosition = cameraPosition + new Vector3(spawnX, spawnY, 0f);

        return spawnPosition;
    }
    private void SetAllEnemiesActive(bool active)
    {
        foreach (var enemy in spawnedEnemies)
        {
            enemy.SetActive(active);
        }
    }

    private void OnBecameVisible()
    {
        SetAllEnemiesActive(true);
    }

    private void OnBecameInvisible()
    {
        SetAllEnemiesActive(false);
    }
}
