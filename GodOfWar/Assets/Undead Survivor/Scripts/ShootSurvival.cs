using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSurvival : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private float timeShoot = 1f;
    private bool isShoot;

    private Coroutine shootingCoroutine;

    private void OnEnable()
    {
        isShoot = true;
        shootingCoroutine = StartCoroutine(ShootTime());
    }

    private void OnDisable()
    {
        isShoot = false;
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    IEnumerator ShootTime()
    {
        while (isShoot)
        {
            Instantiate(prefabBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeShoot);
        }
    }
}
