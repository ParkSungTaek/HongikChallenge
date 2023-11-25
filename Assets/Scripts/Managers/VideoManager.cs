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
    /// 비디오는 메모리가 큼으로 따로 캐싱 관리 
    /// </summary>
    /// <param name="video"></param>
    /// <returns></returns>
    public VideoClip Load(Define.Videos video, bool cashing = true)
    {
        string videoName = Enum.GetName(typeof(Define.Videos), video);
        string path = "Videos/"+ videoName;

        VideoClip videoClip = null;
        //캐시에 존재 -> 캐시에서 반환
        if (_videoClips.TryGetValue(path, out videoClip))
            return videoClip;

        //캐시에 없음 -> 로드하여 캐시에 저장 후 반환
        videoClip = Resources.Load<VideoClip>(path);
        if (videoClip == null) { Debug.LogError("!!NO_VIDEO!!"); }
        if(cashing == true)
        {
            _videoClips.Add(path, videoClip);
        }
        return videoClip;
    }

    /// <summary>
    /// 캐시 초기화
    /// </summary>
    public void Clear()
    {
        _videoClips.Clear();
    }
}
