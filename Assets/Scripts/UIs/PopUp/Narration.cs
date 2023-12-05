using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Narration : UI_Popup
{



    WaitForSeconds[] Seconds = new WaitForSeconds[7];
    

    enum GameObjects
    {

    }
    enum Buttons
    {
    }
    enum Texts
    {
        NarrationTxt,
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();


        for(int i = 1; i < 7; i++)
        {
            Seconds[i] = new WaitForSeconds(i);
        }


        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.PamphletText][0].Count; i++)
        {
            sb.Append(GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.PamphletText][0][i].Script.Replace("{name}", GameManager.InGameData.Name));
            sb.Append("\n");
        }

        GetText((int)Texts.NarrationTxt).text = sb.ToString();

    }


    #region Btn
    void ButtonBind()
    {
        //BindEvent(GetButton((int)Buttons.Button).gameObject, DelPopup);
    }
    void DelPopup(PointerEventData evt)
    {
        GameManager.UI.ClosePopupUI();
    }

    #endregion Btn


    public override void ReOpenPopUpUI()
    {
        
    }   
    

    IEnumerator Intro()
    {
        yield return null;
    }
       
}
