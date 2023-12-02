
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using Client;

public class UI_GameScene : UI_Scene
{
    PlayableController _player { get => GameManager.InGameData.MyPlayer; }
    enum GameObjects
    {
        joystickBG,
        joystickHandle,
    }
    enum Buttons
    {
        JumpBtn,
        Reset,
        Room,
        
    }
    enum Texts
    {

    }




    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        JoystickBind();
        ButtonBind();


    }

    #region Joystick
    /// <summary>
    /// joystick handle 기본 위치
    /// </summary>
    Vector2 _joystickPivotPos;

    /// <summary>
    /// joystick 최대 이동 거리
    /// </summary>
    float _joystickLimit;
    /// <summary>
    /// joystick handle
    /// </summary>
    GameObject _joystickHandle;

    /// <summary>
    /// joystick 방향 벡터
    /// </summary>
    Vector2 _directionVector = Vector2.zero;

    void JoystickBind()
    {
        GameObject joystickBG = Get<GameObject>((int)GameObjects.joystickBG);
        _joystickHandle = Get<GameObject>((int)GameObjects.joystickHandle);

        //기본 위치와 최대 이동 거리 계산
        _joystickPivotPos = _joystickHandle.transform.position;
        _joystickLimit = ((joystickBG.transform as RectTransform).rect.width - (_joystickHandle.transform as RectTransform).rect.width) / 2f;

        //이벤트 bind
        BindEvent(_joystickHandle, JoystickDrag, Define.UIEvent.Drag);
        BindEvent(_joystickHandle, JoystickDragEnd, Define.UIEvent.DragEnd);
    }

    /// <summary>
    /// 조이스틱 드래그
    /// </summary>
    /// <param name="evt"></param>
    void JoystickDrag(PointerEventData evt)
    {
        _directionVector = (evt.position - _joystickPivotPos).normalized;

        _joystickHandle.transform.position = _joystickPivotPos + _directionVector * Mathf.Min((evt.position - _joystickPivotPos).magnitude, 50);

        _player?.SetDirection(_directionVector);

    }

    /// <summary>
    /// 조이스틱 드래그 종료
    /// </summary>
    /// <param name="evt"></param>
    void JoystickDragEnd(PointerEventData evt)
    {
        _directionVector = Vector2.zero;
        _joystickHandle.transform.position = _joystickPivotPos;

        _player?.StopMove();
    }
    #endregion Joystick

    #region Buttons
    void ButtonBind()
    {
        BindEvent(GetButton((int)Buttons.JumpBtn).gameObject, Btn_Jump);
        BindEvent(GetButton((int)Buttons.Reset).gameObject, Btn_Reset);
        BindEvent(GetButton((int)Buttons.Room).gameObject, Btn_BookRoom);

        

    }
    void Btn_Jump(PointerEventData evt)
    {
        _player?.Jump();
    }
    void Btn_Reset(PointerEventData evt)
    {
        GameManager.InGameData.MyPlayer.transform.position = new Vector3(-19.2269211f, 0.640282512f, 21.304493f);
        
      
    }
    void Btn_BookRoom(PointerEventData evt)
    {
        GameManager.InGameData.MyPlayer.transform.position =
        new Vector3(3.54200006f, 0.524675786f, 41.0614433f);

    }
    #endregion Buttons


}
