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

    //[SerializeField] private PlayerHealth playerHealth;

    void Update() {
        if (player.transform.position.y < minHeight && !isDead) // Player falls off screen 
        {
            audioManager.GetComponent<SoundEffects>().PlaySound("GameOver");
            isDead = true;
            StartCoroutine(RespawnAfterDelay()); 
            //playerHealth.decreaseHealth();
        }
    }

    public IEnumerator RespawnAfterDelay() { // Respawn player 
        player.GetComponent<Rigidbody2D>().Sleep(); 
        yield return new WaitForSeconds(time); 
        player.transform.position = RespawnPoint.position;   
        player.GetComponent<Rigidbody2D>().WakeUp(); 

        isDead = false;
    }
}
