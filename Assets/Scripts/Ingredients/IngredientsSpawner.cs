using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawner : MonoBehaviour
{

    // todo populate the food lists
    [SerializeField] private List<GameObject> foods;
    [SerializeField] private float respawnTime = 0.5f;
    [SerializeField] private GameObject bomb;
    private Vector2 screenBounds;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(IngredientWave());
    }

    private IEnumerator IngredientWave()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return wait;

            int choice = Random.Range(0, 6); // a number from 0,1,2,3,4,5 
            // add in logic to spawn the food depending on their probabilty

            if (choice == 5)
            {
                //DropFromSky(bomb);
                //Debug.Log("Spawning bomb");
            }
            else
            {
                DropFromSky(foods[choice]);
                //Debug.Log("Spawning ingredient");
            }
        }
    }

    private void DropFromSky(GameObject go)
    {
        GameObject f = Instantiate(go) as GameObject;
        f.transform.position = new Vector2(RandX(), screenBounds.y);
    }

    private float RandX()
    {
        return Random.Range(-screenBounds.y, screenBounds.y);
    }
}
