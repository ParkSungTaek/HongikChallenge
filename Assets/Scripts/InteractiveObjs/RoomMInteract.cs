using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class RoomMInteract : InteractObj
{
    enum Entitys
    {
        RoomMTexts,
        Q1,
        Q2,
        Q3,
    }
    
    Define.StoryInteractOBJs text = Define.StoryInteractOBJs.Room013;
    TMP_Text roomMtext;
    private void Start()
    {
        Debug.Log($"{Entitys.RoomMTexts}");



    }

    protected override void InteractAction()
    {
        
    }
}
