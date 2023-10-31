
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
        JumpBtn
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
    /// joystick handle �⺻ ��ġ
    /// </summary>
    Vector2 _joystickPivotPos;

    /// <summary>
    /// joystick �ִ� �̵� �Ÿ�
    /// </summary>
    float _joystickLimit;
    /// <summary>
    /// joystick handle
    /// </summary>
    GameObject _joystickHandle;

    /// <summary>
    /// joystick ���� ����
    /// </summary>
    Vector2 _directionVector = Vector2.zero;

    void JoystickBind()
    {
        GameObject joystickBG = Get<GameObject>((int)GameObjects.joystickBG);
        _joystickHandle = Get<GameObject>((int)GameObjects.joystickHandle);

        //�⺻ ��ġ�� �ִ� �̵� �Ÿ� ���
        _joystickPivotPos = _joystickHandle.transform.position;
        _joystickLimit = ((joystickBG.transform as RectTransform).rect.width - (_joystickHandle.transform as RectTransform).rect.width) / 2f;

        //�̺�Ʈ bind
        BindEvent(_joystickHandle, JoystickDrag, Define.UIEvent.Drag);
        BindEvent(_joystickHandle, JoystickDragEnd, Define.UIEvent.DragEnd);
    }

    /// <summary>
    /// ���̽�ƽ �巡��
    /// </summary>
    /// <param name="evt"></param>
    void JoystickDrag(PointerEventData evt)
    {
        _directionVector = (evt.position - _joystickPivotPos).normalized;

        _joystickHandle.transform.position = _joystickPivotPos + _directionVector * Mathf.Min((evt.position - _joystickPivotPos).magnitude, 50);

        _player?.SetDirection(_directionVector);

    }

    /// <summary>
    /// ���̽�ƽ �巡�� ����
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
    }
    void Btn_Jump(PointerEventData evt)
    {
        _player?.Jump();
    }


    #endregion Buttons


}
