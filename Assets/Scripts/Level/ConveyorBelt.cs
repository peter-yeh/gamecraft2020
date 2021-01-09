using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{ 
    //This bool acts as a switch
    private bool playerInCollider;
    //This is where we will store the player object.
    private GameObject playerObj;
    //you can adjust the speed using the float speed. If you want the belt to push right left use a negative number.
    public float speed;

    // 1 means right direction, -1 means left direction
    public float isRight;
    private float flipDirectionTime = 0.0f;
    public float durationBeforeFlip;
    public bool oneBeltOnly;

    public GameObject greenBelt;
    public GameObject redBelt;

    // Update is called once per frame
    void Update()
        {
            if (Time.time > flipDirectionTime && !oneBeltOnly)
            {
                flipDirectionTime += durationBeforeFlip;
                isRight *= -1;
                switchBelts();

            }
            
            if (playerInCollider)
            {
                playerObj.transform.position += transform.right * isRight * (speed * Time.deltaTime);
            }
        }

    private void switchBelts()
    {
        if (!oneBeltOnly)
        {
            if (isRight == 1)
            {
                greenBelt.SetActive(true);
                redBelt.SetActive(false);
            }
            else
            {
                greenBelt.SetActive(false);
                redBelt.SetActive(true);
            }
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
