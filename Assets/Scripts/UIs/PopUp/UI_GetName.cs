using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GetName : UI_Popup
{
    enum Buttons
    {
        ExitBtn,
        Input_NameBtn
    }
    
    enum Texts
    {

    }

    enum TMP_InputFields
    {
        GetName,
    }


    public override void Init()
    {


        base.Init();
        Bind<TMP_InputField>(typeof(TMP_InputFields));
        Bind<Button>(typeof(Buttons));
        BindEventBtn();

       
    }

    #region Btn 
    void BindEventBtn()
    {
        BindEvent(GetButton((int)Buttons.ExitBtn).gameObject, Btn_Exit);
        BindEvent(GetButton((int)Buttons.Input_NameBtn).gameObject, Btn_Input_Name);

    }

    void Btn_Exit(PointerEventData evt)
    {
        GameManager.UI.ClosePopupUI();
    }

    void Btn_Input_Name(PointerEventData evt)
    {
        GameManager.InGameData.Name = Get<TMP_InputField>((int)TMP_InputFields.GetName).text;
    }
    #endregion Btn 


}
