using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    void Start()
    {
        GameObject vp = GameObject.FindGameObjectWithTag("portfolio");
        var videoPlayer = vp.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"Portfolio.mp4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
