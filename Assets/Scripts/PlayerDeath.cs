using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform RespawnPoint;
    public GameObject player; 
    public float minHeight; 
    //private float time = 3f;

    void Update() {
        if (player.transform.position.y < minHeight) //player dies
        {
            player.transform.position = RespawnPoint.position;
            //StartCoroutine(RespawnAfterDelay()); // help how do i delay it falling 
        }  
    }
/*
    public IEnumerator RespawnAfterDelay() {
        player.GetComponent<Rigidbody2D>().Sleep(); //make rigidbody sleep so no physics
        yield return new WaitForSeconds(time); 
        player.transform.position = RespawnPoint.position;   
        player.GetComponent<Rigidbody2D>().WakeUp(); //wake rigidbody up so physics invoked
    }*/
}
