using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class RoomMInteract : InteractObj
{
    enum Entitys
    {
        RoomMTitle,
        RoomMTexts,
        Q0,
        Q1,
        Q2,
        MaxCount
    }
    
    Define.StoryInteractOBJs text = Define.StoryInteractOBJs.Room013;
    TMP_Text[] roomMtext = new TMP_Text[(int)Entitys.MaxCount];
    Dictionary<int, List<Story>> RoomMData = new Dictionary<int, List<Story>>();

    private void Start()
    {
        roomMtext[(int)Entitys.RoomMTitle] = transform.Find($"{Entitys.RoomMTitle}").GetComponent<TMP_Text>();
        RoomMData = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013];

        roomMtext[(int)Entitys.RoomMTexts] = transform.Find($"{Entitys.RoomMTexts}").GetComponent<TMP_Text>();
        RoomMData = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013];

        roomMtext[(int)Entitys.RoomMTexts].text = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.Room013_Explan][0][0].Script;


        roomMtext[(int)Entitys.Q0] = transform.Find($"{Entitys.Q0}").GetComponent<TMP_Text>();

        roomMtext[(int)Entitys.Q1] = transform.Find($"{Entitys.Q1}").GetComponent<TMP_Text>();
        
        roomMtext[(int)Entitys.Q2] = transform.Find($"{Entitys.Q2}").GetComponent<TMP_Text>();


    }

    protected override void InteractAction()
    {
        
    }
}
