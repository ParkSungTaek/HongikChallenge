using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        PamphletText,
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();

        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.PamphletText][0].Count; i++)
        {
            sb.Append(GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.PamphletText][0][i].Script.Replace("{name}", GameManager.InGameData.Name));
            sb.Append("\n");
        }

        GetText((int)Texts.PamphletText).text = sb.ToString();

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
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.PamphletText][0].Count; i++)
        {
            sb.Append(GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.PamphletText][0][i].Script.Replace("{name}", GameManager.InGameData.Name));
            sb.Append("\n");
        }

        GetText((int)Texts.PamphletText).text = sb.ToString();
    }
}