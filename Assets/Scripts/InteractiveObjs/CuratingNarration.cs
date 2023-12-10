using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuratingNarration : MonoBehaviour
{
    bool _curatingNarration = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_curatingNarration)
        {
            _curatingNarration = true;
            GameManager.InGameData.narration.PlayIntro3();
        }
    }
}
