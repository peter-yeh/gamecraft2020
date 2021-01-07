using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeUp : MonoBehaviour
{

    [SerializeField] private GameObject[] recipesObject;
    [SerializeField] private GameObject timeUpText;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);

    private void Start()
    {


        int level = Storage.GetStorage().GetCurrentLevel();
        int[] ingredientBasket = Storage.GetStorage().ingredientBasket;

        List<int> recipeUnlocked = LevelUnlocked.Unlock(ingredientBasket, level);

        Debug.Log("The ingredient basket is: " + String.Join(", ", ingredientBasket));
        Debug.Log("The recipe unlocked is: " + String.Join(", ", recipeUnlocked));

        foreach (int i in recipeUnlocked)
        {
            recipesObject[i].SetActive(true);

            if (i < 3)
            {
                Storage.GetStorage().SetLevelUnlocked(2);
            }
            if (i >= 3)
            {
                Storage.GetStorage().SetLevelUnlocked(3);
            }


        }

        if (recipeUnlocked.Count == 0)
        {
            // help meeee idk how to use the text pro...
            timeUpText.GetComponent<TextMeshProUGUI>().text += "\n Oh no, no new recipes unlocked";
        }
        else
        {
            timeUpText.GetComponent<TextMeshProUGUI>().text += "Yay! You unlocked " + recipeUnlocked.Count + " new recipes";
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    private IEnumerator Flash(GameObject go)
    {
        for (int i = 0; i < 4; i++)
        {
            go.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            go.SetActive(false);
        }
    }

}
