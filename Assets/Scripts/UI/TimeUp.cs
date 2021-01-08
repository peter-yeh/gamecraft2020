using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeUp : MonoBehaviour
{

    [SerializeField] private GameObject[] recipesObject;
    [SerializeField] private GameObject timeUpText;
    private WaitForSeconds wait = new WaitForSeconds(0.3f);

    private void Start()
    {
        int level = Storage.GetStorage().GetCurrentLevel();
        int[] ingredientBasket = Storage.GetStorage().ingredientBasket;

        List<int> recipeUnlocked = LevelUnlocked.Unlock(ingredientBasket, level);
        List<GameObject> tempList = new List<GameObject>();

        //Debug.Log("The ingredient basket is: " + String.Join(", ", ingredientBasket));
        //Debug.Log("The recipe unlocked is: " + String.Join(", ", recipeUnlocked));

        foreach (int i in recipeUnlocked)
        {
            //StartCoroutine(Flash(recipesObject[i]));
            tempList.Add(recipesObject[i]);


            if (i < 3)
            {
                Storage.GetStorage().SetLevelUnlocked(2);
            }
            if (i >= 3 && i < 6)
            {
                Storage.GetStorage().SetLevelUnlocked(3);
            }
            if (i >= 6 && i < 9)
            {
                Storage.GetStorage().SetLevelUnlocked(4);
                int j = 0;
                while (j < 9)
                {
                    if (Storage.GetStorage().getRecipeUnlocked(j))
                    {
                        j++;
                        print("recipes unlocked:" + j);
                    }
                    else
                    {
                        break;
                    }
                }
                if (j == 9)
                {
                    Storage.GetStorage().setCompleted9Recipes();
                }
            }
            if (i == 9)
            {
                Storage.GetStorage().SetLevelUnlocked(5);
            }

        }

        if (recipeUnlocked.Count == 0)
        {
            timeUpText.GetComponent<TextMeshProUGUI>().text += "\n Oh no, no new recipes unlocked";
        }
        else
        {
            timeUpText.GetComponent<TextMeshProUGUI>().text += "Yay! You unlocked " + recipeUnlocked.Count + " new recipes";
        }

        StartCoroutine(ShowAndFlash(tempList));
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    private IEnumerator ShowAndFlash(List<GameObject> gos)
    {
        foreach (GameObject go in gos)
        {
            go.SetActive(true); // shows all recipes unlocked
        }

        for (int i = 0; i < 5; i++)
        {
            foreach (GameObject go in gos)
            {
                go.GetComponent<Image>().color = Color.grey;
            }
  
            yield return wait;
            
            foreach (GameObject go in gos) // this is to ensure they get lit up in sync
            {
                go.GetComponent<Image>().color = Color.white;
            }

            yield return wait;
        }

        //Debug.Log("Done flashing colour of food:" + go.GetComponent<Image>());
    }


    //private IEnumerator Flash(GameObject go)
    //{
    //    go.SetActive(true);

    //    for (int i = 0; i < 5; i++)
    //    {
    //        go.GetComponent<Image>().color = Color.white;

    //        yield return wait;

    //        go.GetComponent<Image>().color = Color.grey;

    //        yield return wait;

    //        //Debug.Log("Reduced colour of food:" + go.GetComponent<Image>());
    //    }
    //}

}
