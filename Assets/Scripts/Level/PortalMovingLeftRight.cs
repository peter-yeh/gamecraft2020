using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMovingLeftRight : MonoBehaviour
{
    public float rightLimit;
    public float leftLimit;
    public float speed;
    private int direction = 1;

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

        transform.position = new Vector2(transform.position.x + speed * direction * Time.deltaTime, transform.position.y);
    }
}
