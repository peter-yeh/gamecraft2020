using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepAudio : MonoBehaviour
{
    static KeepAudio instance = null;
 
    // This script allows music to play between scenes
    void Awake () {
        if (instance != null)
            Destroy (gameObject);
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
