using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteAll();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
}
