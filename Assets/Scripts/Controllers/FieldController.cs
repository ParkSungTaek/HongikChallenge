using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Define.Field ThisField;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.InGameData.MyField = ThisField;
        GameManager.InGameData.SetVisit(ThisField);

        if (ThisField == Define.Field.Lobby && GameManager.InGameData.End())
        {
            //TODO 나레이션 + 엔딩 UI
            GameManager.Sound.Play(Define.SFX.Outro);
            GameManager.UI.ShowPopupUI<UI_Outro>();
        }

    }


}
