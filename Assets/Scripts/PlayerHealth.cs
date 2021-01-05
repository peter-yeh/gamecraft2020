using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //healthBar
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    private int health = 3;

    public PlayerHealth()
    {
        health = 3;
    }

    public void decreaseHealth()
    {
        health -= 1;
        switch (health)
        {
            case 2:
                heart1.enabled = false;
                break;
            case 1:
                heart2.enabled = false;
                break;
            case 0:
                heart3.enabled = false;
                showDeathMenu();
                break;
        }
    }

    public void resetHealth()
    {
        health = 3;
    }

    public void showDeathMenu()
    {
        SceneManager.LoadScene(6);
    }
}
