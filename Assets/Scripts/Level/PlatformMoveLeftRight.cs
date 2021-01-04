using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveLeftRight : MonoBehaviour
{
    public float rightLimit;
    public float leftLimit;
    public float speed;
    //public Rigidbody2D rb;
    private int direction = 1;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }

        //rb.velocity = Vector2.right * speed * direction;
        transform.position = new Vector2(transform.position.x + speed * direction * Time.deltaTime, transform.position.y);
    }
}
