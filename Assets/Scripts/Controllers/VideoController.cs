using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    
    AudioSource Video_AudioSource;
    VideoPlayer _videoPlayer;

    Vector3 MyPos;
    Vector3 Delta;
    GameObject player;

    [SerializeField]
    float MaxDist = 25f;
    public float Dist;
    public float Vol;

    [SerializeField]
    bool thisVideo = false;

    private void Start()
    {
        Video_AudioSource = GetComponent<AudioSource>();
        MyPos = transform.position;
        _videoPlayer = GetComponent<VideoPlayer>();
        if (thisVideo)
        {
            GameManager.InGameData.MyVideoController = this;
        }
    }

    public void VideoPlay()
    {
        _videoPlayer.Play();
    }

    float Distance()
    {
        if (player == null)
        {
            player = GameManager.InGameData.MyPlayer.gameObject;
        }
        Delta = MyPos - player.transform.position;
        Dist = Delta.magnitude;
        return Delta.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if(Distance() > MaxDist)
        {
            Video_AudioSource.volume = 0;
        }
        else
        {
            Vol = ((MaxDist - Distance()) * (MaxDist - Distance())) / (MaxDist * MaxDist);
            Video_AudioSource.volume = ((MaxDist - Distance()) * (MaxDist - Distance())) / (MaxDist * MaxDist);
        }
    }
}
