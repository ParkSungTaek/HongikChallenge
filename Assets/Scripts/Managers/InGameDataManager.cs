using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class InGameDataManager
    {
        public PlayableController MyPlayer { get; private set; }
        public bool StartSequence { get; set; } = true;

        Define.Field _myField = Define.Field.Start;
        public Define.Field MyField { get { return _myField; } set { _myField = value; MyPlayer.SetField(_myField); } } 
        Vector3 StartPoint { get; set; } = Vector3.zero;
        /// <summary> InGameData 게임 시작시 초기화</summary>
        public void Init()
        {
            MyPlayer = GameObject.FindFirstObjectByType<PlayableController>();
            
        }


        /// <summary> 게임 플레이 정보 초기화 </summary>
        public void Clear()
        {
            
        }
    }

}
