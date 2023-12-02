using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Book : UI_Popup
{

    const int Scenario = 0;
    Define.StoryInteractOBJs CuratingType;
    enum GameObjects
    {

    }
    enum Buttons
    {
        Button,
    }
    enum Texts
    {
        Title,
        Name,
        About,
        PamphletText,
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();

    }

    public void SetText(Define.StoryInteractOBJs text)
    {

        StringBuilder sb = new StringBuilder();
        CuratingType = text;
        for (int i = 0; i < GameManager.InGameData.StoryWrapper[text][0].Count; i++)
        {
            sb.Append(GameManager.InGameData.StoryWrapper[text][0][i].Script.Replace("{name}", GameManager.InGameData.Name));
            sb.Append("\n");
        }

        GetText((int)Texts.PamphletText).text = sb.ToString();
    }
    public void GetError(string er)
    {
        GetText((int)Texts.PamphletText).text = er;
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
