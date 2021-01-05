using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    [SerializeField] private float animateRate = 0.5f;

    private void Start()
    {
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
}
