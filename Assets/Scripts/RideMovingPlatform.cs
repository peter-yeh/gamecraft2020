using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideMovingPlatform : MonoBehaviour
{
    //private bool isParentPlatform = false;
    //private Transform parentPlatform;

    // Player can move along with moving platforms
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Moving Platform"))
        {
            Debug.Log("Moving");
            //isParentPlatform = true;
            //parentPlatform = col.transform;
            this.transform.parent = col.transform.parent;
        }
    }

    // Player can move along with moving platforms
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Moving Platform"))
        {
            Debug.Log("Off");
            //isParentPlatform = false;
            //parentPlatform = null;
            this.transform.parent = null;
        }
    }

    //private void LateUpdate()
    //{
    //    if (isParentPlatform)
    //    {
    //        this.transform.parent = parentPlatform.parent;
    //    }
    //    else
    //    {
    //        this.transform.parent = null;
    //    }
    //}
}
