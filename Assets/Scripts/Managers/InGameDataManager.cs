using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class InGameDataManager
    {

        /// <summary> 현재 플레이어 </summary>
        public PlayableController MyPlayer { get; private set; }
        /// <summary> 이미 스타트 시퀀스("실제의 양태")봐야 하나? </summary>
        public bool StartSequence { get; set; } = true;

        Define.Field _myField = Define.Field.Start;
        /// <summary> 플레이어의 위치 "방" 해당 방이 아니면 상호작용 불가 </summary>
        public Define.Field MyField { get { return _myField; } set { _myField = value; MyPlayer.SetField(_myField); } }

        Vector3[] _startPoint = new Vector3[(int)Define.Field.MaxCount];
        /// <summary> 플레이어 전송 위치 </summary>
        public Vector3[] RoomPoint { get { return _startPoint; } private set { _startPoint = value; } }

        bool[] _visitRoom = new bool[(int)Define.Field.MaxCount] { true, false, false, false, false, false, false, false, false, false, false};
        public bool[] VisitRoom { get { return _visitRoom;  } set { _visitRoom = value; } } 


        public void Init()
        {
            MyPlayer = GameObject.FindFirstObjectByType<PlayableController>();
            _startPoint[(int)Define.Field.Lobby] = new Vector3(-2f, 4.0f, 37f);

        }

        /// <summary> 게임 플레이 정보 초기화 </summary>
        public void Clear()
        {
            
        }
    }

}
