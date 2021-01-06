using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal;
    private GameObject player;
    private bool canTeleport;

    private static float teleportTime;
    public float teleportDelay;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleportTime = teleportDelay;
    }

    private void Update()
    {
        if (canTeleport)
        {
            teleportTime += Time.deltaTime;

            if (teleportTime > teleportDelay)
            {
                teleportTime = 0.0f;
                player.transform.position = portal.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            canTeleport = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            canTeleport = false;

        }
    }
}
