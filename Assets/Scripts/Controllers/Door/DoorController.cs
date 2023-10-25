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
    Vector3 _moveDelta = new Vector3(2,0,0);
    const float _openDoorTime = 2.0f;
    const float _tick = 1f / 60f;

    static WaitForSeconds Tick = new WaitForSeconds(_tick);
    bool _canMove = true;
    bool _isOpen = false;
    public bool CanOpen { get; set; } = false;  

    public void EnterBound()
    {
        _textMeshPro.text= "�� ���� ����!";
    }
    public void ExitBound()
    {
        _textMeshPro.text = "��!";

    }
    void Start()
    {
        _doorPhysics = transform.Find("DoorPhysics").gameObject;
        _myBound = transform.Find("DoorActiveBound").GetComponent<DoorActiveBound>();
        _textMeshPro = transform.Find("TextGuide").GetComponent<TextMeshPro>();
        _myBound.SetDoor(this);
    }


    public void OpenOrClose()
    {
        if (CanOpen)
        {
            if (_isOpen)
            {
                StartCoroutine(CloseDoor());
            }
            else
            {
                StartCoroutine(OpenDoor());
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
            
            Vector3 StartVec = _doorPhysics.transform.position;
            Vector3 TargetVec = _doorPhysics.transform.position + _moveDelta;

            float startTime = Time.time;
            float endTime = startTime + _openDoorTime;
            while (Time.time < endTime)
            {
                float t = (Time.time - startTime) / _openDoorTime;
                _doorPhysics.transform.position = Vector3.Lerp(StartVec, TargetVec, t);
                yield return null;
            }

            _doorPhysics.transform.position = TargetVec;
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

            Vector3 StartVec = _doorPhysics.transform.position;
            Vector3 TargetVec = _doorPhysics.transform.position - _moveDelta;
            float startTime = Time.time;
            float endTime = startTime + _openDoorTime;
            while (Time.time < endTime)
            {
                float t = (Time.time - startTime) / _openDoorTime;
                _doorPhysics.transform.position = Vector3.Lerp(StartVec, TargetVec, t);
                yield return null;
            }

            _doorPhysics.transform.position = TargetVec;
            _canMove = true;
        }
    }

}
