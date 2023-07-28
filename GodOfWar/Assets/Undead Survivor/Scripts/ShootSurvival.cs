using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSurvival : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private float timeShoot = 1f;
    bool isShoot;
    void Start()
    {
        StartCoroutine(ShootTime());
    }

    private void OnEnable()
    {
        isShoot = true;
    }

    private void OnDisable()
    {
        isShoot = false;
    }

    void Update()
    {
        /*StartCoroutine(ShootTime());*/
    }

    IEnumerator ShootTime()
    {

        while (isShoot)
        {
            yield return new WaitForSeconds(timeShoot);
            Instantiate(prefabBullet, transform.position, Quaternion.identity);
        }

    }
}
