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
    private Rigidbody2D rb;

    public GameObject audioManager;

    [SerializeField] private PlayerHealth playerHealth;


    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
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

        //player.GetComponent<Rigidbody2D>().Sleep();
        //player.GetComponent<Rigidbody2D>().gravityScale = 0;

        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        player.GetComponent<playerMovement>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;


        player.transform.position = RespawnPoint.position;

        for (int i = 0; i < 4; i++)
        {
            //transform.localScale *= 1.5f;

            player.GetComponent<SpriteRenderer>().color = Color.grey;

            yield return new WaitForSeconds(.3f);

            player.GetComponent<SpriteRenderer>().color = Color.white;

            yield return new WaitForSeconds(.3f);

            //transform.localScale /= 1.5f;
        }

        rb.gravityScale = 1.5f; // super bad coding practise!!! Might cuase bug when trying to set player gravity to other values
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;


        //player.GetComponent<Rigidbody2D>().WakeUp();
        //player.GetComponent<Rigidbody2D>().gravityScale = 1.5f;

        Debug.Log("Player respwan finish");
        isDead = false;

    }
}
