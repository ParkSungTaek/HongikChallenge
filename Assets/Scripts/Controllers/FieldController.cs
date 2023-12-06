using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Define.Field ThisField;
    bool roomM = false;
    bool Ending = false;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.InGameData.MyField = ThisField;
        GameManager.InGameData.SetVisit(ThisField);

        if (ThisField == Define.Field.Lobby && GameManager.InGameData.End() && !Ending)
        {

            //TODO 나레이션 + 엔딩 UI
            GameManager.InGameData.narration.PlayOutro();
            Ending = true;
        }

        if (ThisField == Define.Field.RoomM)
        {
            if (!roomM)
            {
                GameManager.InGameData.narration.PlayroomM();
                roomM = true;
            }
        }


    }


}
