using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer vp;

    // Update is called once per frame
    void Update()
    {
        if (!vp.isPlaying)
        {
            Storage.GetStorage().setVideoPlayed();
            SceneManager.LoadScene(3);
        }

    }
}
