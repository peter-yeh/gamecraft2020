using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    // Collision with ingredients and bombs
    void OnTriggerEnter2D(Collider2D col) {
            //Debug.Log("Collision"); / too spammy lol
            Destroy(col.gameObject); // Destroy the ingredient or bomb 
    }
}
