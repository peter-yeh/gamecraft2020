using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // destroy the object when it collides with the player or smth
    }

}
