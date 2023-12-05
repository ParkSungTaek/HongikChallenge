using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Define.Field ThisField;
    bool roomM = false;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.InGameData.MyField = ThisField;
        GameManager.InGameData.SetVisit(ThisField);

        if (ThisField == Define.Field.Lobby && GameManager.InGameData.End())
        {
            //TODO �����̼� + ���� UI
            GameManager.Sound.Play(Define.SFX.Outro);
            GameManager.UI.ShowPopupUI<UI_Outro>();
        }

        if (ThisField == Define.Field.RoomM)
        {
            if (!roomM)
            {
                GameManager.Sound.Play(Define.SFX.roomM);
                roomM = true;
            }
        }


    }


}
