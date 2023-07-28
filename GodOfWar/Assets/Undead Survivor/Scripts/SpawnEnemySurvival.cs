using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemySurvival : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemy;
    bool isRunning;
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    private void OnEnable()
    {
        isRunning= true;
    }
    private void OnDisable()
    {
        isRunning= false;
    }
    IEnumerator spawnEnemy()
    {
        while (isRunning)
        {
            float time = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(time);
            int rand = Random.Range(0, enemy.Length);
            GameObject enemyToSpawn = enemy[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
