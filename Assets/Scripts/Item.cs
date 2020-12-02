using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: ItemAttributes
{
    /// <summary>
    /// This class inherits from the ItemAttributes class. The inherited variable of Speed determines how much force is applied to the object. The inherited variable of
    /// PointValue determines how many points each item is worth. When a collision is detected the tag of the variable TriggerInfo is checked against a switch statement
    /// and associated code is run.
    /// 
    /// If the tag is Bullet then score is incremented through the PointValue variable of the base class. If the player score is equal to or 
    /// greater than NextLevel then the value of NextLevel is changed and the Level variable in the base class is incremented. It is this Level variable that determines how
    /// much force is applied to an an item.
    ///
    /// If the tag is Player then the MeshRenderer and CapsuleCollider of Player is disabled. The MeshRenderer and collider of the item is also disabled.
    /// 
    /// The Respawn coroutine is then started.
    /// 
    /// if the item exits the collider on the Spawner object, the item is disabled and added back into the que.
    /// </summary>
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
        switch(TriggerInfo.tag)
        {
            case "Bullet":
                Player.Score += PointValue;
                Player.UI.Score.text = Player.Score.ToString();

                if (Player.Score >= Player.NextLevel)
                {
                    Player.Level += 1;
                    Player.UI.Level.text = Player.Level.ToString();

                    Player.NextLevel = Player.NextLevel * Player.Level;
                    Player.UI.NextLevel.text = Player.NextLevel.ToString();
                }
                break;

            case "Player":
                Player.gameObject.GetComponent<MeshRenderer>().enabled = false;
                Player.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                Player.gameObject.GetComponent<PlayerMove>().enabled = false;

                ThisTransform.gameObject.GetComponent<MeshRenderer>().enabled = false;

                BoxCollider Box = ThisTransform.gameObject.GetComponent<BoxCollider>();

                if(Box == null)
                {
                    ThisTransform.gameObject.GetComponent<SphereCollider>(). enabled = false;
                }

                else
                {
                    ThisTransform.gameObject.GetComponent<BoxCollider>().enabled = false;
                }

                StartCoroutine(Player.Respawn());
                break;
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
