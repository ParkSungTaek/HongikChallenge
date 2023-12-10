using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomMCanvas : UI_Popup
{
    int Scenario = 0;
   
    Dictionary<int, List<Story>> RoomMData = new Dictionary<int, List<Story>>();
    
    int[] AnsArr = new int[(int)Ans.MaxCount];
    
    enum Ans
    {
        A1, 
        A2,
        A3,
        MaxCount
    }
    enum Buttons
    {
        Q1,
        Q2,
        Q3,
    }
    enum Texts
    {
        RoomMTitle,
        RoomMTexts,

        Q1_Txt,
        Q2_Txt,
        Q3_Txt,


    }
    public override void Init()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        RoomMData = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013];

        GetText((int)Texts.RoomMTitle).text = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013_Explan][0][0].Script;

        
        ButtonBind();
        SetText();
    }
    private void Start()
    {
        StartCoroutine(AfterLoading());
    }

    IEnumerator AfterLoading()
    {
        yield return new WaitForSeconds(5.0f);
        Init();
    }

    #region Btn
    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.Q1).gameObject, Q1_Btn);
        BindEvent(GetButton((int)Buttons.Q2).gameObject, Q2_Btn);
        

    }


    

    void Q1_Btn(PointerEventData evt)
    {
        int tmpidx = Scenario;
        try
        {
            GameManager.Sound.Play(Define.SFX.sfx_touchScreen);

            Scenario = GameManager.InGameData.QuestionWrapper[Scenario].A1;
            
            if (Scenario < 7)
            {

                SetText();
                
            }
            else
            {

                GameManager.InGameData.ScenarioForEarth = Scenario;

                GameManager.UI.ShowPopupUI<UI_Room013>();
                GameManager.InGameData.ShowEarth((Define.Earths)Scenario - 6);

                Scenario = 0;
                SetText();


                
            }
        }
        catch 
        {
            Debug.LogError($" 버그버그");

        }
    }
    void Q2_Btn(PointerEventData evt)
    {
        try
        {
            Scenario = GameManager.InGameData.QuestionWrapper[Scenario].A2;
            GameManager.Sound.Play(Define.SFX.sfx_touchScreen);


            if (Scenario < 7)
            {
                SetText();
                
            }
            else
            {


                GameManager.InGameData.ScenarioForEarth = Scenario;

                GameManager.UI.ShowPopupUI<UI_Room013>();
                GameManager.InGameData.ShowEarth((Define.Earths)Scenario - 6);

                Scenario = 0;
                SetText();
                
              

            }
        }
        catch
        {
            Debug.LogError($" 버그버그");

        }
        
    }
    void Q3_Btn(PointerEventData evt)
    {
        
    }

    #endregion Btn
    void SetText()
    {
        
        GetText((int)Texts.RoomMTexts).text = RoomMData[Scenario][0].Script;
        string tmp = GameManager.InGameData.QuestionWrapper[RoomMData[Scenario][0].To].Q1.Replace("/n", "\n");
        Debug.Log(tmp); 
        GetText((int)Texts.Q1_Txt).text = tmp;
        GetText((int)Texts.Q2_Txt).text = GameManager.InGameData.QuestionWrapper[RoomMData[Scenario][0].To].Q2.Replace("[/n]", "\n");

    }



    public override void ReOpenPopUpUI()
    {

    }
}
