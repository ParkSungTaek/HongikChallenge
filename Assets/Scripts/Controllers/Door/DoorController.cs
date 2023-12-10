using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using static Define;
using Client;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject _doorPhysics;
    DoorActiveBound _myBound;
    Vector3 _moveDelta = new Vector3(0,0,-80);
    const float _openDoorTime = 2.0f;
    const float _tick = 1f / 60f;

    static WaitForSeconds Tick = new WaitForSeconds(_tick);
    bool _canMove = true;
    bool _isOpen = false;
    public bool CanOpen { get; set; } = false;



    enum DoorType
    {
        ExceptionAtEnd,
        VideoStart,

        MaxCouunt
    }

    
    [SerializeField]
    bool ExceptionAtEnd = false;
    [SerializeField]
    bool VideoStart = false;
    [SerializeField]
    public bool ActiveIntro = false;

    public void ExitBound()
    {
        //_textMeshPro.text = "¹®!";

    }
    void Start()
    {
        _myBound = transform.Find("DoorActiveBound").GetComponent<DoorActiveBound>();
        _myBound.SetDoor(this);
        if (ExceptionAtEnd)
        {
            GameManager.InGameData.EndDoor = this;
        }
    }

    public void SetDoorPhysics(GameObject go)
    {
        _doorPhysics = go;
    }

    public void OpenSequence()
    {
        if (GameManager.InGameData.CanOpenDoor)
        {
            StartCoroutine(OpenDoor());
            if (VideoStart)
            {
                GameManager.InGameData.MyVideoController.VideoPlay();
            }

        }

    }

    IEnumerator OpenDoor()
    {
        if ((!GameManager.InGameData.CantOpen() || ExceptionAtEnd) && !_isOpen && _canMove)
        {
            GameManager.Sound.Play(Define.SFX.sfx_touchDoor);
            _canMove = false;
            _isOpen = true;
            
            Vector3 StartVec = _doorPhysics.transform.localRotation.eulerAngles;
            Vector3 TargetVec = _doorPhysics.transform.localRotation.eulerAngles + _moveDelta;

            float startTime = Time.time;
            float endTime = startTime + _openDoorTime;
            while (Time.time < endTime)
            {
                float t = (Time.time - startTime) / _openDoorTime;
                _doorPhysics.transform.localRotation = Quaternion.Euler(Vector3.Lerp(StartVec, TargetVec, t));
                yield return null;
            }


            yield return new WaitForSeconds(5f);
            if (ExceptionAtEnd && GameManager.InGameData.End())
            {

            }
            else
            {
                _canMove = true;
                StartCoroutine(CloseDoor());
            }
            
        }

    }
    IEnumerator CloseDoor()
    {
        if (_canMove && _isOpen)
        {
            GameManager.Sound.Play(Define.SFX.sfx_touchDoor);
            _canMove = false;
            _isOpen = false;


            Vector3 StartVec = _doorPhysics.transform.localRotation.eulerAngles;
            Vector3 TargetVec = _doorPhysics.transform.localRotation.eulerAngles - _moveDelta;

            float startTime = Time.time;
            float endTime = startTime + _openDoorTime;
            while (Time.time < endTime)
            {
                float t = (Time.time - startTime) / _openDoorTime;
                _doorPhysics.transform.localRotation = Quaternion.Euler(Vector3.Lerp(StartVec, TargetVec, t));
                yield return null;
            }

            _canMove = true;
        }
    }

}
