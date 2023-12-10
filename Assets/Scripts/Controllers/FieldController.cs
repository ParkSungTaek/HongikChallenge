using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Define.Field ThisField;
    bool roomM = false;
    bool startIntro = false;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.InGameData.MyField = ThisField;
        GameManager.InGameData.SetVisit(ThisField);

        if (ThisField == Define.Field.Lobby && !startIntro)
        {
            startIntro = true;
            GameManager.InGameData.narration.PlayIntro5();

        }

        if (ThisField == Define.Field.Lobby && GameManager.InGameData.End() && !GameManager.InGameData.Ending1)
        {

            //TODO 나레이션 + 엔딩 UI
            GameManager.InGameData.narration.PlayOutro1();
            GameManager.InGameData.Ending1 = true;
        }
        if ((ThisField == Define.Field.Start) && GameManager.InGameData.Ending1 && (!GameManager.InGameData.Ending2))
        {
            Debug.Log("??");
            //TODO 나레이션 + 엔딩 UI
            GameManager.InGameData.narration.PlayOutro2();
            GameManager.InGameData.Ending2 = true;
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
