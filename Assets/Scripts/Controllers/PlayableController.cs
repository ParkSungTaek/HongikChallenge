using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

public class PlayableController : MonoBehaviour
{
    /// <summary> �� ��ġ�� ������ ���� ��ġ </summary>
    protected Vector3 _currPosition { get => transform.position + Vector3.up; }
    float Speed = 10f;
    /// <summary> animation ���� �� �ʱ�ȭ </summary>
    protected void Init()
    {
    }


    #region Move
    enum PlayerState
    {
        Idle,
        Move,
        Jump,
    }

    /// <summary> ���� �÷��̾� ���� </summary>
    PlayerState _state = PlayerState.Idle;
    private void FixedUpdate()
    {
        if (_state == PlayerState.Move)
            JoystickMove();
        
    }



    /// <summary> ���̽�ƽ ���� ���� </summary>
    Vector2 _joystickDirection { get; set; } = Vector2.zero;
    Vector3 _moveDirection { get; set; }
    /// <summary> ���̽�ƽ�� �̿��� �÷��̾� ���� ���� </summary>
    public void JoystickMove() {

        _moveDirection = new Vector3(_joystickDirection.x,0, _joystickDirection.y);
        transform.Translate(_moveDirection * Time.deltaTime * Speed); 
    } 
    /// <summary> ���̽�ƽ�� ���� ���� ���� </summary>
    public void SetDirection(Vector2 dir)
    {
        _state = PlayerState.Move;
        _joystickDirection = dir;
        SeeDirection(dir);
    }
    /// <summary> ���̽�ƽ ���� ���� </summary>
    public void StopMove()
    {
        _state = PlayerState.Idle;
    }

    #endregion Move


    #region Jump
    public void Jump()
    {
    }

    #endregion Jump

    #region Animation

    /// <summary>
    /// ��� ��ġ�� ���� �����¿� �� ���� ������ �������� �ִϸ��̼� ������
    /// </summary>
    /// <param name="targetPos">��� ��ġ</param>
    protected int SeeTarget(Vector3 targetPos) => SeeDirection((targetPos - _currPosition).normalized);

    /// <summary>
    /// ���̽�ƽ ���⿡ ���� �����¿� �� ���� ������ �������� �ִϸ��̼� ������
    /// </summary>
    /// <param name="dir">���̽�ƽ ����(normalized)</param>
    protected int SeeDirection(Vector2 dir)
    {
        Vector2 resultDir;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            resultDir = (dir.x < 0 ? Vector2.left : Vector2.right);
        }
        else
            resultDir = (dir.y < 0 ? Vector2.down : Vector2.up);

        
        return GetDirectionIdx(resultDir);
    }

    /// <summary> �ٶ󺸴� ���� int������ ��ȯ </summary>
    int GetDirectionIdx(Vector2 dir)
    {
        if (dir == Vector2.up)
            return 0;
        else if (dir == Vector2.right)
            return 1;
        else if (dir == Vector2.down)
            return 2;
        else
            return 3;
    }

    /// <summary> int �� �������� ��ȯ </summary>
    protected Vector2 GetDirection(int directionIdx)
    {
        switch (directionIdx)
        {
            case 0:
                return Vector2.up;
            case 1:
                return Vector2.right;
            case 2:
                return Vector2.down;
            default:
                return Vector2.right;
        }
    }
    #endregion Animation

}
