using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonInput : MonoBehaviour
{
    public float horizontalInput = 0f;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
    }

    private void OnDisable()
    {
        horizontalInput = 0f;
    }
}
