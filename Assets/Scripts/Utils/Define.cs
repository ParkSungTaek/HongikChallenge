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
        sfx_bear,
        sfx_jumpLand,
        sfx_jumpUp,
        sfx_touchDoor,
        sfx_touchPaper,
        sfx_touchScreen,

        Intro,
        Outro,
        
        TMP_Walk,
        TMP_Door,
        MaxCount
    }
    public enum Walk
    {
        sfx_walk1,
        sfx_walk2,
        sfx_walk3,
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
        CuratingY_Name,
        CuratingY_info0,
        CuratingY_info1,




        CuratingM,
        CuratingM_Name,
        CuratingM_info0,
        CuratingM_info1,



        book1,
        book1_Name,
        book1_info0,
        book1_info1,


        book2,
        book2_Name,
        book2_info0,
        book2_info1,


        book3,
        book3_Name,
        book3_info0,
        book3_info1,

        book4,
        book4_Name,
        book4_info0,
        book4_info1,

        book5,
        book5_Name,
        book5_info0,
        book5_info1,

        book6,
        book6_Name,
        book6_info0,
        book6_info1,

        book7,
        book7_Name,
        book7_info0,
        book7_info1,

        bear1,
        bear2,
        bear3,
        bear4,
        Room013,




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