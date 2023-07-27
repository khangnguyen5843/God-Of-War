using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiBoardController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float torqueForce = 1f;
    private void Awake()
    {
        rigidbody= GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddTorque(-torqueForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddTorque(torqueForce);
        }
    }
}
