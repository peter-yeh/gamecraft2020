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

    // delete this unused method if nth breaks
    //// Destroys this object if it's out of view.
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

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

}
