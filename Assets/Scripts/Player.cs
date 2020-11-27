using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerAttributes
{
    private Rigidbody rb;
    private Transform ThisTransform;
    [SerializeField] float Speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(ThisTransform.forward * Speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-ThisTransform.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.up * -Speed * Time.deltaTime);
        }
    }
}
