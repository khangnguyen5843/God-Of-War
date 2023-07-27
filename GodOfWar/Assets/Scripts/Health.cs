using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    private SpawnPoint spawnPoint;
    

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }

    public void ReSpawn()
    {
        if(currentHealth == 0)
        {
            
        }
    }
}
