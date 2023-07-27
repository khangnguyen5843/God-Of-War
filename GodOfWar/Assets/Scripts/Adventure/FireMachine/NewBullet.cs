using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NewBullet : MonoBehaviour
{
    private Vector3 direction = Vector3.up;
    private float bulletSpeed = 2f;
    private IObjectPool<GameObject> bulletPool;
    void Start()
    {
        
    }
    public void SetPool(IObjectPool<GameObject> LauncherPool)
    {
        bulletPool = LauncherPool;
    }
    public void SetStartPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
    public void SetDirection(Vector3 newDirection)
    {
        newDirection.Normalize();
        direction = newDirection;
    }
    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        bulletPool.Release(this.gameObject);
    }
}
