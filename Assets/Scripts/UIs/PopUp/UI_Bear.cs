using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UI_Bear : UI_Popup
{
    int textIDX = 0;
    int MaxIIDX = 100;
    const int Scenario = 0; 
    List<Story> ScenarioList = new List<Story>();
    Define.StoryInteractOBJs BearType;
    enum GameObjects
    {

    }
    enum Buttons
    {
        Button,
        Right,
        Left,
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

    }

    public void SetText(Define.StoryInteractOBJs text)
    {
        textIDX = 0;
        BearType = text;
        MaxIIDX = GameManager.InGameData.StoryWrapper[BearType][Scenario].Count - 1;
        ScenarioList = GameManager.InGameData.StoryWrapper[BearType][Scenario];
        GetText((int)Texts.PamphletText).text = ScenarioList[textIDX].Script.Replace("{name}", GameManager.InGameData.Name);
        LeftRightActiveControl();
    }
    void LeftRightActiveControl()
    {
        if (textIDX <= 0)
        {
            GetButton((int)Buttons.Left).gameObject.SetActive(false);
        }
        else
        {
            GetButton((int)Buttons.Left).gameObject.SetActive(true);

        }
        if (textIDX >= MaxIIDX)
        {
            GetButton((int)Buttons.Right).gameObject.SetActive(false);
        }
        else
        {
            GetButton((int)Buttons.Right).gameObject.SetActive(true);
        }
    }
    public void GetError(string er)
    {
        GetText((int)Texts.PamphletText).text = er;
    }


    #region Btn
    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.Button).gameObject, DelPopup);
        BindEvent(GetButton((int)Buttons.Right).gameObject, Btn_Right);
        BindEvent(GetButton((int)Buttons.Left).gameObject, Btn_Left);

        

    }
    void DelPopup(PointerEventData evt)
    {
        GameManager.UI.ClosePopupUI();
    }
    
    void Btn_Right(PointerEventData evt)
    {
        textIDX++;
        GetText((int)Texts.PamphletText).text = ScenarioList[textIDX].Script.Replace("{name}", GameManager.InGameData.Name);
        LeftRightActiveControl();
    }
    void Btn_Left(PointerEventData evt)
    {
        textIDX--;
        GetText((int)Texts.PamphletText).text = ScenarioList[textIDX].Script.Replace("{name}", GameManager.InGameData.Name);
        LeftRightActiveControl();
    }
    #endregion Btn


    public override void ReOpenPopUpUI()
    {
        //textIDX = 0;
        //GetText((int)Texts.PamphletText).text = ScenarioList[textIDX].Script.Replace("{name}", GameManager.InGameData.Name);
        //LeftRightActiveControl();
    }
}
