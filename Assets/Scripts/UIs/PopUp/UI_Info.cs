using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Info : UI_Popup
{
    const int Default = 0;
    Define.StoryInteractOBJs _Name;
    Define.StoryInteractOBJs _info0;
    Define.StoryInteractOBJs _info1;
    Define.StoryInteractOBJs _Script;
    ScrollRect scrollRect;
    enum GameObjects
    {

    }
    enum Buttons
    {
        Button,
    }
    enum Texts
    {
        Name,
        info0,
        info1,
        PamphletText,
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));
        scrollRect = transform.Find("Scroll View").GetComponent<ScrollRect>();

        ButtonBind();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="info0"></param>
    /// <param name="info1"></param>
    /// <param name="Script"></param>
    public void SetText(Define.StoryInteractOBJs Name, Define.StoryInteractOBJs info0, Define.StoryInteractOBJs info1, Define.StoryInteractOBJs Script)
    {

        StringBuilder sb = new StringBuilder();

        _Name = Name;
        _info0 = info0;
        _info1 = info1;
        _Script = Script;
        
        for (int i = 0; i < GameManager.InGameData.StoryWrapper[Script][Default].Count; i++)
        {
            sb.Append(GameManager.InGameData.StoryWrapper[Script][Default][i].Script);
            sb.Append("\n");
        }
        GetText((int)Texts.Name).text = GameManager.InGameData.StoryWrapper[Name][Default][0].Script;
        GetText((int)Texts.info0).text = GameManager.InGameData.StoryWrapper[info0][Default][0].Script;
        GetText((int)Texts.info1).text = GameManager.InGameData.StoryWrapper[info1][Default][0].Script;
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
        scrollRect.verticalNormalizedPosition = 1.0f;
    }
}
