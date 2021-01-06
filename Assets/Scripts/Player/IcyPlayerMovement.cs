using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcyPlayerMovement : playerMovement
{
    public float icySpeed;


    private void FixedUpdate()
    {
        bool grounded = IsGrounded();

        if (grounded)
        {
            Vector2 Movement = new Vector2(mx, 0);
            rb.AddForce(Movement * icySpeed);

        } else
        {
            Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

            rb.velocity = movement;
        }
    }


}
