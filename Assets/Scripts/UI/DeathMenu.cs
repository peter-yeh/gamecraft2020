using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void ReturnToMap()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartLevel()
    {
        int currentLevel = Storage.GetStorage().GetCurrentLevel();
        SceneManager.LoadScene(currentLevel + 2);
    }
}
