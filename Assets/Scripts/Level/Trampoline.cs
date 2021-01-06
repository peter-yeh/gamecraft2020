using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float thrust;
    [SerializeField] private Animator trampolineController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Liftoff");
            //isActivated = true;
            trampolineController.SetTrigger("isActivated");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }
    }
}
