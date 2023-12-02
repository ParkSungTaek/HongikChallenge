using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;
using static PlayableController;

public class PlayableController : MonoBehaviour
{
    #region Data
    /// <summary> �� ��ġ�� ������ ���� ��ġ </summary>
    protected Vector3 _currPosition { get => transform.position + Vector3.up; }


    public bool[] _visitRoom = new bool[(int)Define.Field.MaxCount];
    


    /// <summary> �÷��̾� ���ǵ� </summary>
    float _speed = 5f;
    /// <summary> �÷��̾� Rigidbody </summary>
    Rigidbody _myRd;


    public enum WallDetectorEnum
    {
        Front,
        Back,
        Right,
        Left,
        MaxCount
    }
    WallDetector[] _wallDetector = new WallDetector[(int)WallDetectorEnum.MaxCount];
    

    float _JumpPower = 6f;
    public bool CanJump  = true;
    #endregion Data

    
    private void Start()
    {
        _myRd = GetComponent<Rigidbody>();
        _wallDetector[(int)WallDetectorEnum.Front] = transform.Find("Front").GetComponent<WallDetector>();
        _wallDetector[(int)WallDetectorEnum.Back] = transform.Find("Back").GetComponent<WallDetector>();
        _wallDetector[(int)WallDetectorEnum.Left] = transform.Find("Left").GetComponent<WallDetector>();
        _wallDetector[(int)WallDetectorEnum.Right] = transform.Find("Right").GetComponent<WallDetector>();

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

    void Idle_PlayerState()
    {
        if(_state != PlayerState.Idle)
        {
            WalkSound_End();

            _state = PlayerState.Idle;
        }
            
    }

    void Move_PlayerState()
    {
        if (_state != PlayerState.Move)
        {
            WalkSound_Start();
            _state = PlayerState.Move;
        }

    }

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

        float x = _joystickDirection.x, y = _joystickDirection.y;
        if (_wallDetector[(int)WallDetectorEnum.Front].Detecting)
        {
            y = Mathf.Min(_joystickDirection.y, 0);
        }
        if (_wallDetector[(int)WallDetectorEnum.Back].Detecting)
        {
            y = Mathf.Max(_joystickDirection.y, 0);
        }
        if (_wallDetector[(int)WallDetectorEnum.Right].Detecting)
        {
            x = Mathf.Min(_joystickDirection.x, 0);
        }
        if (_wallDetector[(int)WallDetectorEnum.Left].Detecting)
        {
            x = Mathf.Max(_joystickDirection.x, 0);
        }
        _moveDirection = new Vector3(x, 0, y); 

        transform.Translate(_moveDirection * Time.deltaTime * _speed);
        
    }

    

    /// <summary> ���̽�ƽ�� ���� ���� ���� </summary>
    public void SetDirection(Vector2 dir)
    {
        Move_PlayerState();
        _joystickDirection = dir;

        SeeDirection(dir);
    }
    /// <summary> ���̽�ƽ ���� ���� </summary>
    public void StopMove()
    {
        Idle_PlayerState();
    }

    #endregion Move


    #region Jump
    public void Jump()
    {
        if (CanJump)
        {
            CanJump = false;
            GameManager.Sound.Play(Define.SFX.sfx_jumpUp);
            _myRd.AddForce(transform.up * _JumpPower, ForceMode.Impulse);
        }
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

    #region Sound
    private void WalkSound_Start()
    {
        switch (GameManager.InGameData.MyField) 
        {
            case Define.Field.RoomY:
                GameManager.Sound.WalkPlay(Define.Walk.sfx_walk2);
                break;
            case Define.Field.RoomM:
                GameManager.Sound.WalkPlay(Define.Walk.sfx_walk3);
                break;
            default:
                GameManager.Sound.WalkPlay(Define.Walk.sfx_walk1);
                break;
        }

    }
    private void WalkSound_End()
    {
        GameManager.Sound.StopWalkPlay();

    }
    #endregion Sound


}
