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
        Source,
        SourcePage,
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        
          
        ButtonBind();
        GetButton((int)Buttons.SourcePage).gameObject.SetActive(false);
    }


    #region Btn
    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.Del).gameObject, DelPopup);
        BindEvent(GetButton((int)Buttons.Source).gameObject, SourceBtn);
        BindEvent(GetButton((int)Buttons.SourcePage).gameObject, SourcePageBtn);



    }
    void DelPopup(PointerEventData evt)
    {
        GameManager.UI.ClosePopupUI();
        SceneManager.LoadScene(Define.Scenes.GameScene);

    }
    void SourceBtn(PointerEventData evt)
    {
        GetButton((int)Buttons.SourcePage).gameObject.SetActive(true);

    }
    void SourcePageBtn(PointerEventData evt)
    {
        GetButton((int)Buttons.SourcePage).gameObject.SetActive(false);

    }

    #endregion Btn

    public override void ReOpenPopUpUI()
    {

    }
}
