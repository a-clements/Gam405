using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ItemAttributes
{
    [SerializeField]private Vector3 PlayerPosition;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnDisable()
    {
        PlayerPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.MoveTowards(this.transform.position, PlayerPosition, 1.0f * Time.deltaTime);
    }
}
