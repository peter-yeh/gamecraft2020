using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobSpawner : MonoBehaviour
{

    // todo populate the food lists
    [SerializeField] private List<GameObject> blobs;
    public float respawnTime;
    public bool credits = false;
    private Vector2 screenBounds;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(BlobWave());
    }

    private IEnumerator BlobWave()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTime);

        while (true)
        {
            yield return wait;

            int choice = Random.Range(0, 3); // a number from 0,1,2
            // add in logic to spawn the blobs depending on their probabilty
            DropFromSky(blobs[choice]);

            if (!credits) {
                DropFromSky(blobs[3]); 
                DropFromSky(blobs[4]);                                  
                DropFromSky(blobs[5]); 
                DropFromSky(blobs[6]); 
                credits = true;
            }
        }
    }

    private void DropFromSky(GameObject go)
    {
        GameObject f = Instantiate(go) as GameObject;
        f.transform.position = new Vector2(RandX(), screenBounds.y);
        f.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-90, 90));
        f.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(-10, 10), ForceMode2D.Impulse);
    }

    private float RandX()
    {
        return Random.Range(-screenBounds.y, screenBounds.y);
    }
}
