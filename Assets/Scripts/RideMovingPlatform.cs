using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideMovingPlatform : MonoBehaviour
{
    //Transform parentPlatform;

    // Player can move along with moving platforms
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Moving Platform"))
        {
            Debug.Log("Moving");
            //parentPlatform = col.transform;
            this.transform.parent = col.transform.parent;
        }
    }

    // Player can move along with moving platforms
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Moving Platform"))
        {
            Debug.Log("Moving");
            //parentPlatform = null;
            this.transform.parent = null;
        }
    }

    //private void LateUpdate()
    //{
    //    if (parentPlatform != null)
    //    {
    //        transform.position = new Vector2(transform.position.x + parentPlatform.position.x, transform.position.y);
    //    }
    //}
}
