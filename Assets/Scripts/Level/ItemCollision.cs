using UnityEngine;

public class ItemCollision : MonoBehaviour
{

    // Collision with ingredients and bombs
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;
        Destroy(go);
    }

}
