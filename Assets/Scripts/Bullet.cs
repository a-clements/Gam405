using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a very simple class that disables the object upon colliding with another object that is tagged as Enemy. The update function limits the distance the bullet
/// object can travel before being disabled.
/// </summary>
public class Bullet : MonoBehaviour
{
    public float Distance;

    private void OnEnable()
    {
        //called second
    }

    private void Awake()
    {
        //called first
    }

    private void Start()
    {
        //called third
    }

    private void OnTriggerEnter(Collider TriggerInfo)
    {
        if (TriggerInfo.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            TriggerInfo.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (this.transform.position.y > Distance || this.transform.position.y < -Distance || this.transform.position.x > Distance || this.transform.position.x < -Distance)
        {
            this.gameObject.SetActive(false);
        }
    }
}
