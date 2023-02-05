using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }
    void EndReached(VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        if (videoPlayer.gameObject.activeInHierarchy) {
            Debug.Log("Hola Videopatas");
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
