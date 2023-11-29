using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{

    public enum WebDataType
    {

    }
    public enum Sounds
    {
        BGM,
        SFX,
        Walk,
        MaxCount
    }


    public enum Videos
    {
        TmpTest,
        MaxCount
    }
    public enum BGM
    {

        MaxCount
    }
    public enum SFX
    {
        TMP_Walk,
        TMP_Door,
        MaxCount
    }
    public enum State
    {
        MaxCount
    }

    public enum Tag
    {
        MaxCount
    }

    /// <summary>
    /// UI Event 종류 지정
    /// </summary>
    public enum UIEvent
    {
        Click,
        Drag,
        DragEnd,
    }

    public enum Scenes
    {
        Title,
        Loby,
        Game,
    }

    public enum Field
    {
        Start,

        Lobby,

        RoomS1,
        RoomS2,
        RoomM,
        RoomY,

        Path_L2Start,
        Path_L2M,
        Path_L2S1,
        Path_L2Y,

        MaxCount


    }

    public enum InteractableObjs
    {
        Object0,

    }

    public enum StoryInteractOBJs
    {
        PamphletText,
        Ball,
        Box,
        Curating,
        CuratingS,
        CuratingY,
        CuratingM,
        book1,
        book2,
        book3,
        book4,
        book5,
        book6,
        book7,
        bear1,
        bear2,
        bear3,
        bear4,
        

       

        MaxCount,
    }
    public enum ActionData
    {
        Question,
        End,


        None,
        MaxCount,
    }


}