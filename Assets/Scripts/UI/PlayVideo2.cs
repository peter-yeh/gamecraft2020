using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideo2 : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        vp.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Blobtext2.mp4");
        vp.Play();
    }

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
