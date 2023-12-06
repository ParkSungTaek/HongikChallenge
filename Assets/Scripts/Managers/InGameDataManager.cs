using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Client
{
    public class InGameDataManager
    {

        #region GoogleSheet
        public List<int> UseableQuestion;

        public StoryWrapper StoryWrapper = new StoryWrapper();

        public QuestionWrapper QuestionWrapper = new QuestionWrapper();

        #endregion GoogleSheet



        public string Name { get; set; } = "";
        PlayableController myPlayer;

        /// <summary> 현재 플레이어 </summary>
        public PlayableController MyPlayer { 
            get 
            {
                if (myPlayer == null) 
                {
                    myPlayer = GameObject.FindFirstObjectByType<PlayableController>();
                }
                return myPlayer; 
            } 
            private set 
            { 
                myPlayer = value; 
            } 
        }
        /// <summary> 이미 스타트 시퀀스("실제의 양태")봐야 하나? </summary>
        public bool StartSequence { get; set; } = true;

        Define.Field _myField = Define.Field.Start;
        /// <summary> 플레이어의 위치 "방" 해당 방이 아니면 상호작용 불가 </summary>
        public Define.Field MyField { get { return _myField; } set { _myField = value; } }

        Vector3[] _startPoint = new Vector3[(int)Define.Field.MaxCount];
        /// <summary> 플레이어 전송 위치 </summary>
        public Vector3[] RoomPoint { get { return _startPoint; } private set { _startPoint = value; } }



        bool[] _visitRoom = new bool[(int)Define.Field.MaxCount];
        /// <summary>
        /// 아웃트로를 위한 
        /// </summary>
        public bool[] VisitRoom { get { return _visitRoom;  } set { _visitRoom = value; } } 


        public int ScenarioForEarth { get; set; }
        public GameObject[] Earths { get; set; } = new GameObject[(int)Define.Earths.MaxCount];

        public Define.StoryInteractOBJs Narration { get; set; } = Define.StoryInteractOBJs.intro;
        public Narration narration { get; set; }

        public void ShowEarth(Define.Earths earth)
        {
            for(int i=0;i< (int)Define.Earths.MaxCount; i++)
            {
                Earths[i].SetActive(false);
            }
            Earths[(int)earth].SetActive(true);
        }

        public bool End()
        {
            bool end = true;
            for(int i = 0 ; i < (int)Define.Field.MaxCount;i++)
            {
                if (!_visitRoom[i])
                {
                    end = false; break;
                }
            }
            return end;
        }
        public void SetVisit(Define.Field field)
        {
            VisitRoom[(int)field] = true;
            MyPlayer._visitRoom[(int)field] = true;

        }
        public void ClearVisit()
        {
            for (int i = 0; i < (int)Define.Field.MaxCount; i++)
            {
                _visitRoom[i] = false;
            }
        }



        public void Init()
        {
            MyPlayer = GameObject.FindFirstObjectByType<PlayableController>();
            _startPoint[(int)Define.Field.Lobby] = new Vector3(-2f, 4.0f, 37f);
            SetVisit(Define.Field.Start);

        }

        /// <summary> 게임 플레이 정보 초기화 </summary>
        public void Clear()
        {
            ClearVisit();
            SetVisit(Define.Field.Start);
        }
    }

}
