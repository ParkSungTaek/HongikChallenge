using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager 
{
    Dictionary<string, VideoClip> _videoClips = new Dictionary<string, VideoClip>();
    // Start is called before the first frame update
    public void Init()
    {
        Load(Define.Videos.TmpTest);

    }
    /// <summary>
    /// ������ �޸𸮰� ŭ���� ���� ĳ�� ���� 
    /// </summary>
    /// <param name="video"></param>
    /// <returns></returns>
    public VideoClip Load(Define.Videos video, bool cashing = true)
    {
        string videoName = Enum.GetName(typeof(Define.Videos), video);
        string path = "Videos/"+ videoName;

        VideoClip videoClip = null;
        //ĳ�ÿ� ���� -> ĳ�ÿ��� ��ȯ
        if (_videoClips.TryGetValue(path, out videoClip))
            return videoClip;

        //ĳ�ÿ� ���� -> �ε��Ͽ� ĳ�ÿ� ���� �� ��ȯ
        videoClip = Resources.Load<VideoClip>(path);
        if (videoClip == null) { Debug.LogError("!!NO_VIDEO!!"); }
        if(cashing == true)
        {
            _videoClips.Add(path, videoClip);
        }
        return videoClip;
    }

    /// <summary>
    /// ĳ�� �ʱ�ȭ
    /// </summary>
    public void Clear()
    {
        _videoClips.Clear();
    }
}
