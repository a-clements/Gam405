using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerAttributes
{
    /// <summary>
    /// This script inherits from PlayerAttributes. The OnTriggerExit function allows the player to wrap around the play area. That is to say that if the player exits from
    /// the bottom of the play area, it will reappear at the top of the play area. Likewise if the player exits from the left side of the play area, they will reappear
    /// on the right side of the play area. the Respawn function resets the position of the player to 0,0,0 and cancels out any physics operations.
    /// This Respawn function also enables the MeshRenderer, CapsuleCollider, and PlayerMove components.
    /// </summary>
    public Rigidbody rb;
    public Transform ThisTransform;
    private Vector3 Position;
    public float PlayerSpeed = 128.0F;
    public BulletSpawn BulletSpawn;
    public InGameUI UI;
    [SerializeField] private float RespawnTimer = 1.0F;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
        BulletSpawn = FindObjectOfType<BulletSpawn>();
        UI = FindObjectOfType<InGameUI>();
        UI.NextLevel.text = NextLevel.ToString();
        UI.Level.text = Level.ToString();
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
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(RespawnTimer);

        ThisTransform.gameObject.GetComponent<MeshRenderer>().enabled = true;
        ThisTransform.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        ThisTransform.gameObject.GetComponent<PlayerMove>().enabled = true;

        yield return null;
    }
}
