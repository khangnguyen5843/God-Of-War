using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
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
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
