using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawner : MonoBehaviour
{

    // todo populate the food lists
    [SerializeField] private List<Ingredients> foods;
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] private float respawnTime = 0.5f;
    [SerializeField] private GameObject tempFood; // will be deleted and replaced by foods list


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

            // add in logic to spawn the food depending on their probabilty
            spawnIngredient(tempFood);
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
