using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    Vector2 topRight;
    Vector2 botLeft;
    public static int levelThunder=0 ;
    
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

            topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
            botLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

            //DetectEnemy();

            if(levelThunder == 3)
            {
                var enemy2 = FindObjectsByType<MovementEnemySurvival>(FindObjectsSortMode.None);
                GameObject enemy = enemy2[Random.Range(0, enemy2.Count())].gameObject;
                if (enemy != null && enemy.transform.position.x < topRight.x && enemy.transform.position.x > botLeft.x &&
                 enemy.transform.position.y < topRight.y && enemy.transform.position.y > botLeft.y
                 )
                {
                    Instantiate(Thunder, enemy.transform.position, Quaternion.identity);

                    Debug.Log("aaa" + enemy.GetInstanceID());
                }
                else
                {
                    DetectEnemy();
                    Debug.Log("aaa" + enemy.GetInstanceID());
                }
            }
        }
    }
    public void DetectEnemy()
    {
        

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
