using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_pickup : MonoBehaviour
{
    [SerializeField] private int amountXP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovementPlayerSurvival player = collision.GetComponent<MovementPlayerSurvival>();
            if (player != null)
            {
                player.AddExperience(amountXP);

                Destroy(gameObject);
            }
        }
    }
}
