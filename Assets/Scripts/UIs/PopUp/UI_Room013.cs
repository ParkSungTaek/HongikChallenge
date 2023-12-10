using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Room013 : UI_Popup
{
    const int Scenario = 0;
    
    Dictionary<int, List<Story>> RoomMData = new Dictionary<int, List<Story>>();

    ScrollRect scrollRect;
    enum Images
    {
        ansImg,
    }
    enum Buttons
    {
        Button,
    }
    enum Texts
    {
        Title,
        //Name,
        //About,
        PamphletText,
    }
    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();
        scrollRect = transform.Find("Scroll View").GetComponent<ScrollRect>();
        RoomMData = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013];
        SetText(GameManager.InGameData.ScenarioForEarth);
    }

    public void SetText(int Senario)
    {

        StringBuilder sb = new StringBuilder();
        

        GetText((int)Texts.Title).text = RoomMData[Senario][0].Script;

        for (int i = 1; i < RoomMData[Senario].Count; i++)
        {
            sb.Append(RoomMData[Senario][i].Script);
            sb.Append("\n");
        }
        GetText((int)Texts.PamphletText).text = sb.ToString();

        Get<Image>((int)Images.ansImg).sprite = GameManager.Resource.Load<Sprite>($"Sprites/answers/answer{Senario - 6}");

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
        RoomMData = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013];
        SetText(GameManager.InGameData.ScenarioForEarth);
        scrollRect.verticalNormalizedPosition = 1.0f;
    }
}
