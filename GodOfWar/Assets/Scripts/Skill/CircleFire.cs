using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFire : MonoBehaviour
{
    [SerializeField] private GameObject circleFire;
    [SerializeField] private SpriteRenderer sphereFire;
    [SerializeField] private Collider2D sphereSphere;
    [SerializeField] private bool isCircleFire;

    [SerializeField] private int damageCircle = 10;

    private CharacterStat chacracterStat;

    private void OnEnable()
    {
        isCircleFire = true;
        sphereSphere.enabled = true;
        sphereFire.enabled = true;
    }

    private void OnDisable()
    {
        isCircleFire = false;
        sphereSphere.enabled = false;
        sphereFire.enabled = false;
    }

    public void SetChacterStat(CharacterStat circleDamge)
    {
        chacracterStat = circleDamge;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            MovementEnemySurvival enemy = other.GetComponent<MovementEnemySurvival>();
            if (enemy != null)
            {
                int damageCircles = CharacterStat.Instance.CalculateDamage();
                damageCircle = damageCircles / damageCircle;
                enemy.TakeDamage(damageCircle);
                Debug.Log("Circle: " + damageCircle);
            }
        }
    }
}
