using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPeg : MonoBehaviour
{
    [SerializeField] private Animator pegController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pegController.SetTrigger("SlimeBounce");
        }
    }
}
