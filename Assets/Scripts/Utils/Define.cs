using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{

    
    public enum Sounds
    {
        BGM,
        SFX,
        Walk,
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
        Room1,
        Room2,
        Room3,
        Room4,

        Path1,
        Path2,
        Path3,
        Path4,
        Path5,

        MaxCount


    }

    public enum InteractableObjs
    {
        Object0,

    }
}