using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerAttributes
{
    private Rigidbody rb;
    private Transform ThisTransform;
    private Vector3 Position;
    [SerializeField] float PlayerSpeed = 128.0F;
    private BulletSpawn BulletSpawn;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
        BulletSpawn = FindObjectOfType<BulletSpawn>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(ThisTransform.forward * PlayerSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-ThisTransform.forward * PlayerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if(rb.velocity.y < 10.0f)
            {
                rb.AddForce(ThisTransform.up * PlayerSpeed * Time.deltaTime, ForceMode.Force);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.y > -10.0f)
            {
                rb.AddForce(ThisTransform.up * -PlayerSpeed * Time.deltaTime, ForceMode.Force);
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            BulletSpawn.Shoot();
        }
    }

    private void OnTriggerExit(Collider TriggerInfo)
    {
        if(TriggerInfo.tag == "Spawner")
        {
            Position = ThisTransform.position;

            if(Position.y >= Spawner.MaxY || Position.y <= Spawner.MinY)
            {
                Position.y *= -1.0f;
            }
            else if (Position.x >= Spawner.MaxX || Position.x <= Spawner.MinX)
            {
                Position.x *= -1.0f;
            }

            ThisTransform.position = Position;
        }
    }
}
