using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ3 : InteractObj
{
    protected override void InteractAction()
    {
        GameManager.InGameData.MyPlayer.transform.position = GameManager.InGameData.RoomPoint[(int)Define.Field.Lobby];
    
        
    }

}
