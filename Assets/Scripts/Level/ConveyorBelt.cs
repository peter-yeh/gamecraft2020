using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{ 
    //This bool acts as a switch
    public bool playerInCollider;
    //This is where we will store the player object.
    public GameObject playerObj;
    //you can adjust the speed using the float speed. If you want the belt to push right left use a negative number.
    public float speed;

    // 1 means right direction, -1 means left direction
    private float isRight = 1;
    private float flipDirectionTime = 0.0f;
    public float durationBeforeFlip;


    // Update is called once per frame
    void Update()
        {
        if (Time.time > flipDirectionTime)
        {
            flipDirectionTime += durationBeforeFlip;
            isRight *= -1;

        }
            //We are building this script so that future iterations can handle multiple objects on the belt
            if (playerInCollider)
            {
                //This is one to go about motivating a non-rigidbody element. The player may have a rigidbody but the 
                //controller input should be affecting his velocity so we don't want to mess with that
                playerObj.transform.position += transform.right * isRight * (speed * Time.deltaTime);
            }
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            //Enter is good for a player detetion because we just need when the player first enters the collider.
            // The player will need a rigidbody2d for this detection to work.
            if (col.gameObject.tag == "Player")
            {
                // "Player" is a standard tag in the editor you can change your player's tag in the drop down.
                Debug.Log("Player in the coveyor");
                // Remeber to always delete uncessary debugs before building.
                playerObj = col.gameObject;
                playerInCollider = true;
            }
        }
        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                // "Player" is a standard tag in the editor you can change your player's tag in the drop down.
                Debug.Log("Player left the coveyor");
                // Remeber to always delete uncessary debus before building.
                playerInCollider = false;
            }
        }
    }
