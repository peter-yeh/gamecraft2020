using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color defaultColor;

    // Collision with ingredients and bombs
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;

        //if (go.GetComponent<Ingredients>() != null)
        //{
        //    StartCoroutine(FlashWhite(go));

        //}
        //Destroy(go);


    }

    //private IEnumerator FlashWhite(GameObject go)
    //{
    //    WaitForSeconds wait = new WaitForSeconds(0.5f);
    //    SpriteRenderer sprite = go.GetComponent<SpriteRenderer>();
    //    Debug.Log("Running FlashWhite");

    //    // set to flash twice
    //    for (int i = 0; i < 2; i++)
    //    {
    //        yield return wait;
    //        sprite.color = Color.white;

    //        yield return wait;
    //        sprite.color = Color.clear;

    //    }
    //    Destroy(go);
    //}
}
