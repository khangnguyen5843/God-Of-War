using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private bool isFire = true;
    private float angle = 0;

    private IObjectPool<GameObject> bulletPool;

    private void OnEnable()
    {
        isFire = true;
    }
    private void OnDisable()
    {
        isFire = false;
    }
    private void OnDestroy()
    {
        isFire= false;
    }
    private void Awake()
    {
        bulletPool = new ObjectPool<GameObject>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize: 100);
        angle += transform.rotation.eulerAngles.z;
        StartCoroutine(Fire());
    }

    private void OnDestroyBullet(GameObject obj)
    {
       //Vuot qua kich thuoc toi da roi ne :))
       Destroy(obj);
    }

    private void OnReleaseBullet(GameObject obj)
    {
      //chua den kich thuoc toi da
      obj.gameObject.SetActive(false);
    }

    private void OnGetBullet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
        obj.GetComponent<NewBullet>().SetStartPosition(transform.position);
        float x = Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = Mathf.Cos(angle * Mathf.Deg2Rad);
        Vector3 B = new Vector3(x, y, 0);
        obj.GetComponent<NewBullet>().SetDirection(B);
    }

    private GameObject CreateBullet()
    {
        GameObject bulletObject = Instantiate(bullet);
        bulletObject.GetComponent<NewBullet>().SetPool(bulletPool);
        return bulletObject;
    }

    IEnumerator Fire()
    {
        while (isFire)
        {
            yield return new WaitForSeconds(1f);
           /* GameObject bulletObject =  Instantiate(bullet);
            bulletObject.GetComponent<NewBullet>().SetStartPosition(transform.position);
       
            float x = Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = Mathf.Cos(angle * Mathf.Deg2Rad);
            Vector3 B = new Vector3(x, y, 0);
            bulletObject.GetComponent<NewBullet>().SetDirection(B);
            angle += 10;*/
           bulletPool.Get();
            angle += 10;
        }
     
    }
    void Update()
    {
        
    }
}
