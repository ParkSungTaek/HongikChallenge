using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Outro : UI_Popup
{
    
    enum Buttons
    {
        Del,
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
 
        ButtonBind();

    }


    #region Btn
    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.Del).gameObject, DelPopup);



    }
    void DelPopup(PointerEventData evt)
    {
        GameManager.UI.ClosePopupUI();
        SceneManager.LoadScene(Define.Scenes.GameScene);


    }

    #endregion Btn

    public override void ReOpenPopUpUI()
    {

    }
}
