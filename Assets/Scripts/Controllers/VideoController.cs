using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    
    AudioSource Video_AudioSource;

    Vector3 MyPos;
    Vector3 Delta;
    GameObject player;
    const float MaxDist = 25f;
    public float Dist;
    public float Vol;

    private void Start()
    {
        Video_AudioSource = GetComponent<AudioSource>();
        MyPos = transform.position;
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
