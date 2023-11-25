using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject _doorPhysics;
    DoorActiveBound _myBound;
    TextMeshPro _textMeshPro;
    Vector3 _moveDelta = new Vector3(0,0,-80);
    const float _openDoorTime = 2.0f;
    const float _tick = 1f / 60f;

    static WaitForSeconds Tick = new WaitForSeconds(_tick);
    bool _canMove = true;
    bool _isOpen = false;
    public bool CanOpen { get; set; } = false;  

    public void EnterBound()
    {
        _textMeshPro.text= "문 열기 가능!";
    }
    public void ExitBound()
    {
        //_textMeshPro.text = "문!";

    }
    void Start()
    {
        _myBound = transform.Find("DoorActiveBound").GetComponent<DoorActiveBound>();
        _textMeshPro = transform.Find("TextGuide").GetComponent<TextMeshPro>();
        _myBound.SetDoor(this);
    }

    public void SetDoorPhysics(GameObject go)
    {
        _doorPhysics = go;
    }

    public void OpenOrClose()
    {
        if (CanOpen)
        {
            if (_isOpen)
            {
                StartCoroutine(CloseDoor());
                Debug.Log("OpenCo");
            }
            else
            {
                StartCoroutine(OpenDoor());
                Debug.Log("CloseCo");

            }
        }
    }

    
    IEnumerator OpenDoor()
    {
        if (_canMove && !_isOpen)
        {
            GameManager.Sound.Play(Define.SFX.TMP_Door);
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

            _canMove = true;


        }
    }
    IEnumerator CloseDoor()
    {
        if (_canMove && _isOpen)
        {
            GameManager.Sound.Play(Define.SFX.TMP_Door);
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
