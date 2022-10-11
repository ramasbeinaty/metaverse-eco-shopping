using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class CalculateFoodPrint : MonoBehaviour
{
    // shopping cart
    public static List<string> itemsInBasket = new List<string>();
    private int itemsCount = 0;

    // video player
    VideoPlayer videoPlayer;
    bool playingVideo = false;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("Video Screen").GetComponent<VideoPlayer>();
        videoPlayer.source = UnityEngine.Video.VideoSource.Url;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Object entered the trigger");
    }

    void OnTriggerStay (Collider other)
    {
        // check if video player is playing
        if (!videoPlayer.isPlaying)
        {
            playingVideo = false;
        }

        if (other.gameObject.CompareTag("turkey")){
            itemsCount++;

            // play video if video player is not playing
            if (!playingVideo)
            {

                // videoPlayer.clip = Resources.Load<VideoClip>("Assets/Videos/Turkey.mp4");
                //videoPlayer.url = Path.Combine(Application.persistentDataPath,"Assets/Videos/Turkey.mp4");
                videoPlayer.url = "D:\\VR\\MRTK-Project\\Assets\\Videos\\Turkey.mp4";

                videoPlayer.Play();
                playingVideo = true;
            }
            
        }

        UnityEngine.Debug.Log("Object is within trigger -"+ other.gameObject.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < itemsInBasket.Count; i++)
        {
            if (itemsInBasket[i].Contains(other.tag)) // (you use the word "contains". either equals or indexof might be appropriate)
            {
                itemsInBasket.RemoveAt(i);
                itemsCount--;
            }
        }

        UnityEngine.Debug.Log("Object exited trigger");

    }
}
