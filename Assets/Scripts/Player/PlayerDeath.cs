using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform RespawnPoint;
    public GameObject player;
    public float minHeight;
    private float time = 1.5f;
    private bool isDead = false;

    public GameObject audioManager;

    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        if (player.transform.position.y < minHeight && !isDead) // Player falls off screen 
        {
            isDead = true;
            StartCoroutine(RespawnAfterDelay());
            playerHealth.decreaseHealth();
            if (!playerHealth.lastLife)
            {
                audioManager.GetComponent<SoundEffects>().PlaySound("GameOver");
            }
        }
    }

    public IEnumerator RespawnAfterDelay()
    { // Respawn player
        player.GetComponent<Rigidbody2D>().Sleep();
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<playerMovement>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.transform.position = RespawnPoint.position;

        for (int i = 0; i < 5; i++)
        {
            //transform.localScale *= 1.5f;
            //player.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.5f);
            //player.GetComponent<SpriteRenderer>().color = Color.;
            //transform.localScale /= 1.5f;
        }

        player.GetComponent<Rigidbody2D>().WakeUp();
        player.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        isDead = false;

    }
}
