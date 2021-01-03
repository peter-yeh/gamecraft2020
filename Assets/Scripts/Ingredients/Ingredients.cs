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

    // Destroys this object if it's out of view.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
