using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ItemAttributes
{
    private Player Player;
    private Transform PlayerTransform;
    private Rigidbody rb;
    private Transform ThisTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        PlayerTransform = Player.gameObject.transform;
        rb.AddForce((PlayerTransform.position - ThisTransform.position) * (Player.Level * Speed), ForceMode.Force);
    }

    private void OnTriggerEnter(Collider TriggerInfo)
    {
        if(TriggerInfo.tag == "Bullet")
        {
            Player.Score += PointValue;

            if (Player.Score >= Player.NextLevel)
            {
                Player.Level += 1;

                Player.NextLevel = Player.NextLevel * Player.Level;
            }
        }

        if (TriggerInfo.tag == "Player")
        {
            rb.velocity = Vector3.zero;
            //PlayerTransform.position = Vector3.zero;
            ThisTransform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider TriggerInfo)
    {
        if (TriggerInfo.tag == "Spawner")
        {
            rb.velocity = Vector3.zero;
            PlayerTransform.position = Vector3.zero;
            ThisTransform.gameObject.SetActive(false);
        }
    }
}
