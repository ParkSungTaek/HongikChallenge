using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : InteractObj
{
    [SerializeField]
    GameObject _bearUI;
   
    protected override void InteractAction()
    {
        GameManager.Sound.Play(Define.SFX.sfx_bear);
        _bearUI.SetActive(true);
    }

}
