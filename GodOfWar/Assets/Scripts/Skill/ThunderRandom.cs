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
    private int damageThunder = 20;
    void Start()
    {
        StartCoroutine(SpawnThunder());
    }
    Vector2 topRight;
    Vector2 botLeft;
    public static int levelThunder = 3 ;
    [SerializeField] private bool isActive;
    
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnThunder()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);
            float randomX = Random.value;
            float randomY = Random.value;
            Vector3 spawnLocation = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 0));

            topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
            botLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

            //DetectEnemy();

            if (levelThunder == 3)
            {
                var enemy1 = FindObjectsByType<MovementEnemySurvival>(FindObjectsSortMode.None);
                GameObject enemy01 = enemy1[Random.Range(0, enemy1.Count())].gameObject;
                if (enemy01 != null && enemy01.transform.position.x < topRight.x && enemy01.transform.position.x > botLeft.x &&
                 enemy01.transform.position.y < topRight.y && enemy01.transform.position.y > botLeft.y
                 )
                {
                    Instantiate(Thunder, enemy01.transform.position, Quaternion.identity);

                    Debug.Log("aaa" + enemy01.GetInstanceID());
                }
                else
                {
                    DetectEnemy();
                    Debug.Log("aaa" + enemy01.GetInstanceID());
                }
                var enemy2 = FindObjectsByType<MovementEnemySurvival>(FindObjectsSortMode.None);
                GameObject enemy02 = enemy2[Random.Range(0, enemy2.Count())].gameObject;
                if (enemy02 != null && enemy02.transform.position.x < topRight.x && enemy02.transform.position.x > botLeft.x &&
                 enemy02.transform.position.y < topRight.y && enemy02.transform.position.y > botLeft.y
                 )
                {
                    Instantiate(Thunder, enemy02.transform.position, Quaternion.identity);

                    Debug.Log("aaa" + enemy02.GetInstanceID());
                }
                else
                {
                    DetectEnemy();
                    Debug.Log("aaa" + enemy02.GetInstanceID());
                }
                var enemy3 = FindObjectsByType<MovementEnemySurvival>(FindObjectsSortMode.None);
                GameObject enemy03 = enemy3[Random.Range(0, enemy3.Count())].gameObject;
                if (enemy03 != null && enemy03.transform.position.x < topRight.x && enemy03.transform.position.x > botLeft.x &&
                 enemy03.transform.position.y < topRight.y && enemy03.transform.position.y > botLeft.y
                 )
                {
                    Instantiate(Thunder, enemy03.transform.position, Quaternion.identity);

                    Debug.Log("aaa" + enemy03.GetInstanceID());
                }
                else
                {
                    DetectEnemy();
                    Debug.Log("aaa" + enemy03.GetInstanceID());
                }

            }
        }
    }
    public void DetectEnemy()
    {
        

      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Enemy"))
            {
                MovementEnemySurvival enemy = other.GetComponent<MovementEnemySurvival>();
                if (enemy != null)
                {
                    int damageThun = CharacterStat.Instance.CalculateDamage();
                damageThunder = damageThun + damageThunder;
                    enemy.TakeDamage(damageThunder);
                    Debug.Log("Thunder: " + damageThunder);
                }
            }
    }
}
