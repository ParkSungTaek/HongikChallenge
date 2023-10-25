using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

public class PlayableController : MonoBehaviour
{
    /// <summary> 모델 위치를 감안한 보정 위치 </summary>
    protected Vector3 _currPosition { get => transform.position + Vector3.up; }
    float Speed = 10f;
    /// <summary> animation 연결 및 초기화 </summary>
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

    /// <summary> 현재 플레이어 상태 </summary>
    PlayerState _state = PlayerState.Idle;
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

        _moveDirection = new Vector3(_joystickDirection.x,0, _joystickDirection.y);
        transform.Translate(_moveDirection * Time.deltaTime * Speed); 
    } 
    /// <summary> 조이스틱에 따라 방향 결정 </summary>
    public void SetDirection(Vector2 dir)
    {
        _state = PlayerState.Move;
        _joystickDirection = dir;
        SeeDirection(dir);
    }
    /// <summary> 조이스틱 조작 종료 </summary>
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

}
