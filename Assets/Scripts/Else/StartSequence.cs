using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Google.GData.Spreadsheets.ListEntry;

public class StartSequence : MonoBehaviour
{
    
    float MaskSpeed = 25f;
    GameObject _spriteMask;
    const float _customFrame = 1f / 60f;

    float _fadeOutTime { get; set; } = 1.0f;

    WaitForSecondsRealtime _waitrealtime = new WaitForSecondsRealtime(_customFrame);
    Coroutine _coroutine; 

    void Start()
    {
        if (GameManager.InGameData.StartSequence)
        {
            GameManager.InGameData.StartSequence = false;
            _spriteMask = transform.Find("SpriteMask").gameObject;
            _coroutine = StartCoroutine(CustomUpdate());
            Time.timeScale = 0;
        }
        else
        {
            if(_spriteMask == null)
            {
                //_spriteMask = transform.Find("SpriteMask").gameObject;
                Destroy(this.gameObject);

            }
        }
    }

    // Update is called once per frame
    float _time = 0;
    IEnumerator CustomUpdate()
    {
        yield return new WaitForSecondsRealtime(1f);
        while (true)
        {
            yield return _waitrealtime;
            _time += _customFrame;
            _spriteMask.transform.localScale = _spriteMask.transform.localScale + new Vector3(2 * _customFrame * MaskSpeed, Time.fixedDeltaTime * MaskSpeed, 0);
        
            if( _time >= _fadeOutTime) 
            {
                Destroy(this.gameObject);
                GameScene.Init();
            }
        
        }
    }

}
