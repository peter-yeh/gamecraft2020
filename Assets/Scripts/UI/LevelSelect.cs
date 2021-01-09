using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;
    [SerializeField] private GameObject level4;

    private int sceneID;

    // levelID 1,2,3
    public void SelectLevel(int levelID)
    {
        sceneID = levelID + 2;
        Storage.GetStorage().SetCurrentLevel(levelID);
        Debug.Log("The level selected is: " + levelID);

        switch (levelID)
        {
            case 1:
                if (Storage.GetStorage().hasVideoPlayed())
                {
                    level1.SetActive(true);
                } else
                {
                    SceneManager.LoadScene(1);
                }
                break;
            case 2:
                level2.SetActive(true);
                break;
            case 3:
                level3.SetActive(true);
                break;
            case 4:
                level4.SetActive(true);
                break;
        }
    }

    public void exitPanel()
    {
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(sceneID);
    }

}
