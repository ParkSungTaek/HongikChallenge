using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BearUI : UI_Popup
{

    int textIDX = 0;
    int MaxIIDX = 100;
    const int Scenario = 0;
    List<Story> ScenarioList;
    [SerializeField]
    Define.StoryInteractOBJs BearType;

    enum Buttons
    {
        Right,
    }
    enum Texts
    {
        BearText
    }

    public override void Init()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ScenarioList = GameManager.InGameData.StoryWrapper[BearType][Scenario];
        MaxIIDX = GameManager.InGameData.StoryWrapper[BearType][Scenario].Count - 1;
        

        ButtonBind();
        ShowText();

    }


    void ShowText()
    {
        GetText((int)Texts.BearText).text = ScenarioList[textIDX].Script.Replace("/n","\n");
    }

    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.Right).gameObject, Btn_Right);
    }

    void Btn_Right(PointerEventData evt)
    {
        textIDX++;
        if( textIDX > MaxIIDX)
        {
            textIDX = 0;
            ShowText();
            gameObject.SetActive(false);
            
        }
        else
        {
            ShowText();
        }

    }

    private void Awake()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();
    }

    private void OnEnable()
    {

        ScenarioList = GameManager.InGameData.StoryWrapper[BearType][Scenario];
        MaxIIDX = GameManager.InGameData.StoryWrapper[BearType][Scenario].Count - 1;
        ShowText();
    }



}
