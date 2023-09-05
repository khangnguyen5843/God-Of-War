using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSurvival : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    /*public bool isMouseClick;*/
    private void OnEnable()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
        /*isMouseClick = false;*/
    }
    private void OnDisable()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
        /*isMouseClick = false;*/
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        /*isMouseClick = Input.GetMouseButtonDown(0);*/
    }
}
