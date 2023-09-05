using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandom : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    [SerializeField]
    GameObject Thunder;
    void Start()
    {
        StartCoroutine(SpawnThunder());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnThunder()
    {
        while (true)
        {

            yield return new WaitForSeconds(5);
            float randomX = Random.value;
            float randomY = Random.value;
            Vector3 spawnLocation = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 0));
            Instantiate(Thunder, spawnLocation,Quaternion.identity);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
