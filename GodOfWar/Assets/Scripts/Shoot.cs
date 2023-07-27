using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefabBullet;

    private PlayerInput playerInput;
    void Start()
    {
        playerInput= GetComponent<PlayerInput>();
    }
    void Update()
    {
        if(playerInput.isMouseClick)
        {
            Instantiate(prefabBullet,transform.position,Quaternion.identity);
        }   
    }
}
