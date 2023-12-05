using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Book2 : UI_Popup
{
    enum Buttons
    {
        Button,
    }
    enum Texts
    {

    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();

    }

   


    #region Btn
    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.Button).gameObject, DelPopup);
    }
    void DelPopup(PointerEventData evt)
    {
        GameManager.UI.ClosePopupUI();
    }

    #endregion Btn


    public override void ReOpenPopUpUI()
    {
    }

   
}
