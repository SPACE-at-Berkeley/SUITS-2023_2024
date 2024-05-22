using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CameraFeed : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string streamUrl = "https://upload.wikimedia.org/wikipedia/commons/9/97/The_Earth_seen_from_Apollo_17.jpg"; 
    //https://mars.nasa.gov/system/resources/detail_files/25904_1-PIA24546-1200.jpg

    void Start()
    {
        videoPlayer.url = streamUrl;
        videoPlayer.playOnAwake = true;
        videoPlayer.isLooping = true;

        // Optionally, prepare the video to start playing
        videoPlayer.Prepare();
        videoPlayer.Play();
    }
}