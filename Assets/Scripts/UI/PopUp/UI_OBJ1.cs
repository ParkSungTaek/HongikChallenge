using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_OBJ1 : UI_Popup
{
    enum GameObjects
    {

    }
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
        Bind<GameObject>(typeof(GameObjects));
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

}
