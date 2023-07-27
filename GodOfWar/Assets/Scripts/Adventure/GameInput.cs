using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public float horizontalInput =0f;
    public bool isJumpBtn = false;
    public bool isMouseDown = false;
 
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (!isJumpBtn)
        {
            isJumpBtn = Input.GetKeyDown(KeyCode.Space);
        }
        if(!isMouseDown)
        {
            isMouseDown = Input.GetMouseButtonDown(0);
        }

    }
    private void OnDisable()
    {
        horizontalInput= 0;
        isJumpBtn= false;
        isMouseDown = false;    
    }
}
