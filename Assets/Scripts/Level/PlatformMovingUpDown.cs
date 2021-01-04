using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovingUpDown : MonoBehaviour
{
    public float upLimit;
    public float downLimit;
    public float speed;
    private int direction = 1;

    void LateUpdate()
    {
        if (transform.position.y > upLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < downLimit)
        {
            direction = 1;
        }

        //rb.velocity = Vector2.right * speed * direction;
        transform.position = new Vector2(transform.position.x, speed * direction * Time.deltaTime + transform.position.y);
    }
}
