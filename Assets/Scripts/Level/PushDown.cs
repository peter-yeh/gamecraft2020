using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDown : MonoBehaviour
{
    public bool pushRight;
    public float thrust;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            if (pushRight)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * thrust);
            } else
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(-1* transform.right * thrust);
            }

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(-1* transform.up * thrust);
        }
    }
}
