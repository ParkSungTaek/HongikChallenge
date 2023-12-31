using Client;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Define;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager _instance;
    static GameManager Instance { get { Init(); return _instance; } }
    GameManager() { }
    
    #endregion
    
    #region Managers

    ResourceManager _resourceManager = new ResourceManager();
    SoundManager _soundManager = new SoundManager();
    InGameDataManager _inGameDataManager = new InGameDataManager();
    UIManager _uiManager = new UIManager();
    NetworkManager _networkManager = new NetworkManager();
    VideoManager _videoManager = new VideoManager(); 
    RoomManager _roomManager = new RoomManager();  

    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }
    public static InGameDataManager InGameData { get { return Instance._inGameDataManager; } }
    public static UIManager UI { get { return Instance._uiManager; } }
    
    public static NetworkManager Network { get {  return Instance._networkManager; } }
    public static VideoManager Video { get { return Instance._videoManager; } }
    public static RoomManager Room { get { return Instance._roomManager; } }

    #endregion

    /// <summary> instance 생성, 산하 매니저들 초기화 </summary>
    static void Init()
    {
        if (_instance == null)
        {
            GameObject gm = GameObject.Find("GameManager");
            if (gm == null)
            {
                gm = new GameObject { name = "GameManager" };
                gm.AddComponent<GameManager>();
            }
            _instance = gm.GetComponent<GameManager>();
            DontDestroyOnLoad(gm);


            
            _instance._soundManager.Init();
            _instance._inGameDataManager.Init();
            _instance._networkManager.Init();
            _instance._videoManager.Init();
            _instance._roomManager.Init();


            /// 네트워크 통신부
            Instance.StartCoroutine(Network.GoogleSheetsDataParsing("1nBrhxNgQEHWYugVG7jgLYT7q17WND4ErQoTBJJk2120",Network.data.GetStoryData));
            Instance.StartCoroutine(Network.GoogleSheetsDataParsing("1nBrhxNgQEHWYugVG7jgLYT7q17WND4ErQoTBJJk2120", Network.data.GetQuestionData , "924231598"));

        }

    }
    public static void Clear()
    {
        _instance._resourceManager.Clear();
        _instance._soundManager.Clear();
    }


}