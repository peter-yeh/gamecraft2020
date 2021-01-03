using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawner : MonoBehaviour
{

    // todo populate the food lists
    [SerializeField] private List<GameObject> foods;
    [SerializeField] private float respawnTime = 0.5f;
    private Vector2 screenBounds;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(ingredientWave());
    }

    private IEnumerator ingredientWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            int choice = Random.Range(0, 5); // choice a number from 0,1,2,3,4 
            // add in logic to spawn the food depending on their probabilty

            spawnIngredient(foods[choice]);
            Debug.Log("Spawning ingredient");
        }
    }

    private void spawnIngredient(GameObject go)
    {
        GameObject f = Instantiate(go) as GameObject;
        f.transform.position = new Vector2(randX(), screenBounds.y);
    }

    private float randX()
    {
        return Random.Range(-screenBounds.y, screenBounds.y);
    }
}
