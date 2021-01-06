using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OUCH");
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-direction * 10, ForceMode2D.Impulse);
        }
    }
}
