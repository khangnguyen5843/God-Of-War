using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDemo : MonoBehaviour
{
    void Start()
    {
        Vector2 A = new Vector2(3,4);
        Vector2 B = new Vector2(-1,1);
        A.Normalize();
        B.Normalize();
        float dot = Vector2.Dot(A, B);
        float angleRad = Mathf.Acos(dot);
        float angle = angleRad * Mathf.Rad2Deg;
        float angleVerify = Vector2.Angle(A, B);
        Debug.Log("Angle:" + angle);
        Debug.Log("AngleVerify:"+ angleVerify);
    }
    void Update()
    {
        
    }
}
