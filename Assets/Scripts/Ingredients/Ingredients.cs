using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    [SerializeField] private float animateRate = 0.5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        WaitForSeconds wait = new WaitForSeconds(animateRate);

        while (true)
        {
            // Should not cause preformance drop
            yield return wait;
            transform.localScale *= 1.1f;

            yield return wait;
            transform.localScale /= 1.1f;

        }
    }

    //public void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (!col.gameObject.CompareTag("Player"))
    //    {
    //        StartCoroutine(FlashWhite());
    //    }
    //}

    //private IEnumerator FlashWhite()
    //{
    //    WaitForSeconds wait = new WaitForSeconds(0.5f);
    //    SpriteRenderer sprite = transform.GetComponent<SpriteRenderer>();
    //    Debug.Log("Running FlashWhite");

    //    // set to flash twice
    //    for (int i = 0; i < 2; i++)
    //    {
    //        yield return wait;
    //        sprite.color = Color.white;

    //        yield return wait;
    //        sprite.color = Color.clear;

    //    }

    //    //Destroy(transform);
    //}


}
