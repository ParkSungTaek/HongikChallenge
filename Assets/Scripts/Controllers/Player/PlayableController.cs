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
    /// <summary> 모델 위치를 감안한 보정 위치 </summary>
    protected Vector3 _currPosition { get => transform.position + Vector3.up; }


    public bool[] _visitRoom = new bool[(int)Define.Field.MaxCount];
    


    /// <summary> 플레이어 스피드 </summary>
    float _speed = 5f;
    /// <summary> 플레이어 Rigidbody </summary>
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

    /// <summary> 현재 플레이어 상태 </summary>
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



    /// <summary> 조이스틱 방향 벡터 </summary>
    Vector2 _joystickDirection { get; set; } = Vector2.zero;
    Vector3 _moveDirection { get; set; }
    /// <summary> 조이스틱을 이용한 플레이어 직접 조종 </summary>
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

    

    /// <summary> 조이스틱에 따라 방향 결정 </summary>
    public void SetDirection(Vector2 dir)
    {
        Move_PlayerState();
        _joystickDirection = dir;

        SeeDirection(dir);
    }
    /// <summary> 조이스틱 조작 종료 </summary>
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
    /// 대상 위치에 따라 상하좌우 중 가장 근접한 방향으로 애니메이션 돌리기
    /// </summary>
    /// <param name="targetPos">대상 위치</param>
    protected int SeeTarget(Vector3 targetPos) => SeeDirection((targetPos - _currPosition).normalized);

    /// <summary>
    /// 조이스틱 방향에 따라 상하좌우 중 가장 근접한 방향으로 애니메이션 돌리기
    /// </summary>
    /// <param name="dir">조이스틱 방향(normalized)</param>
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

    /// <summary> 바라보는 방향 int값으로 변환 </summary>
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

    /// <summary> int 값 방향으로 변환 </summary>
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
