using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerAttributes
{
    private Rigidbody rb;
    private Transform ThisTransform;
    [SerializeField] float Speed;
    private Vector3 Position;

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
            rb.AddForce(ThisTransform.up * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.AddForce(ThisTransform.up * -Speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider TriggerInfo)
    {
        if(TriggerInfo.name == "Spawner")
        {
            Position = new Vector3(ThisTransform.position.x, ThisTransform.position.y, ThisTransform.position.z);
            Position.x *= -1.0f;
            Position.y *= -1.0f;
            ThisTransform.position = Position;
        }
    }
}
