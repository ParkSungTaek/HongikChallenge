using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sounds.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    float _bgmvolume = 1.0f;
    float _sfxvolume = 1.0f;

    public float BGMVolume { get { return _bgmvolume; } set { PlayerPrefs.SetFloat("BGMVolume", value >= 1 ? 1 : value); } }
    public float SFXVolume { get { return _sfxvolume; } set { PlayerPrefs.SetFloat("SFXVolume", value >= 1 ? 1 : value); } }

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");

        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            UnityEngine.Object.DontDestroyOnLoad(root);

            for (Define.Sounds s = Define.Sounds.BGM; s < Define.Sounds.MaxCount; s++)
            {
                GameObject go = new GameObject { name = $"{s}" };
                _audioSources[(int)s] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sounds.BGM].loop = true;
            _audioSources[(int)Define.Sounds.Walk].loop = true;

        }
        else
        {
            for (Define.Sounds s = Define.Sounds.BGM; s < Define.Sounds.MaxCount; s++)
            {
                GameObject go = root.transform.Find($"{s}").gameObject;
                _audioSources[(int)s] = go.GetComponent<AudioSource>();
            }

            _audioSources[(int)Define.Sounds.BGM].loop = true;
            _audioSources[(int)Define.Sounds.Walk].loop = true;
        }

        _bgmvolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        _sfxvolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

    }
    #region Play
    /// <summary>
    /// SFX용 PlayOneShot으로 구현 
    /// </summary>
    /// <param name="SFXSound"> Define.SFX Enum 에서 가져오기를 바람 </param>
    /// <param name="volume"></param>

    public void Play(Define.SFX SFXSound)
    {
        string path = $"{SFXSound}";
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.SFX);
        Play(audioClip, Define.Sounds.SFX);
    }
    /// <summary>
    /// BGM용 Play로 구현
    /// </summary>
    /// <param name="BGMSound">Define.BGM Enum 에서 가져오기를 바람 </param>
    /// <param name="volume"></param>
    public void Play(Define.BGM BGMSound)
    {
        string path = $"{BGMSound}";
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.BGM);
        Play(audioClip, Define.Sounds.BGM);
    }

    /// <summary>
    /// 걷기는  Loop 로 음악을 사용해야 하나 BGM은 아니고 겹쳐서 들려야 하므로 따로 사용해준다.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="volume"></param>
    public void WalkPlay(Define.Walk walk)
    {
        string path = $"{walk}";
        AudioClip audioClip = GetOrAddAudioClip(path, Define.Sounds.Walk);
        Play(audioClip, Define.Sounds.Walk);

    }
    public void StopWalkPlay()
    {

        AudioSource audioSource = _audioSources[(int)Define.Sounds.Walk];
        if (audioSource.isPlaying)
            audioSource.Stop();


    }
    void Play(AudioClip audioClip, Define.Sounds type = Define.Sounds.SFX)
    {
        if (audioClip == null)
            return;

        if (type == Define.Sounds.BGM)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.BGM];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else if(type == Define.Sounds.Walk)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.Walk];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sounds.SFX];
            audioSource.PlayOneShot(audioClip);
        }
    }
    #endregion Play

    AudioClip GetOrAddAudioClip(string path, Define.Sounds type = Define.Sounds.SFX)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;

        if (type == Define.Sounds.BGM)
        {
            audioClip = GameManager.Resource.Load<AudioClip>(path);
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = GameManager.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }

    public void SetVolume(Define.Sounds type, float volume )
    {
        _audioSources[(int)type].volume = volume;
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }
}
