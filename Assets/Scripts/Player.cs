using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerAttributes
{
    public Rigidbody rb;
    private Transform ThisTransform;
    private Vector3 Position;
    [SerializeField] float PlayerSpeed = 128.0F;
    private BulletSpawn BulletSpawn;
    public InGameUI UI;
    [SerializeField] private float RespawnTimer = 5.0F;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
        BulletSpawn = FindObjectOfType<BulletSpawn>();
        UI = FindObjectOfType<InGameUI>();
        UI.NextLevel.text = NextLevel.ToString();
        UI.Level.text = Level.ToString();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(ThisTransform.forward * PlayerSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
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

    public IEnumerator Respawn()
    {
        ThisTransform.rotation = Quaternion.identity;
        ThisTransform.localRotation = Quaternion.identity;
        ThisTransform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        
        yield return new WaitForSeconds(RespawnTimer);

        ThisTransform.gameObject.SetActive(true);

        yield return null;
    }
}
