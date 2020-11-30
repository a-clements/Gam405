using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ItemAttributes
{
    private Player Player;
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

        rb.AddForce((Player.gameObject.transform.position - ThisTransform.position) * (Player.Level * Speed), ForceMode.Force);
    }

    private void OnTriggerEnter(Collider TriggerInfo)
    {
        if(TriggerInfo.tag == "Bullet")
        {
            Player.Score += PointValue;
            Player.UI.Score.text = Player.Score.ToString();

            if (Player.Score >= Player.NextLevel)
            {
                Player.Level += 1;
                Player.UI.Level.text = Player.Level.ToString();

                Player.NextLevel = Player.NextLevel * Player.Level;
                Player.UI.NextLevel.text = Player.NextLevel.ToString();
            }
        }

        if (TriggerInfo.tag == "Player")
        {
            Player.gameObject.SetActive(false);
            StartCoroutine(Player.Respawn());
            //ThisTransform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider TriggerInfo)
    {
        if (TriggerInfo.tag == "Spawner")
        {
            rb.velocity = Vector3.zero;
            ThisTransform.gameObject.SetActive(false);
        }
    }
}
