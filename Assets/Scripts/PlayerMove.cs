using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player
{
    /// <summary>
    /// This class is used define how the player can move using the physics system. It does so by applying a force or torque to the game object based on player input.
    /// It also allows the player to shoot.
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(ThisTransform.forward * PlayerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-ThisTransform.forward * PlayerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.y < 10.0f)
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

        if (Input.GetKey(KeyCode.Space))
        {
            BulletSpawn.Shoot();
        }
    }
}
