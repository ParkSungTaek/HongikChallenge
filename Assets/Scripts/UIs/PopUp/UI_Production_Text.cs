using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Production_Text : UI_Popup
{
    const float _tickTime = 0.35f;
    const float _endTime = 7.0f;
    const float _startTime = 1.0f;
    const float _customFrame = 1f / 60f;
    const float MaskSpeed = 5f;
    float _fadeOutTime { get; set; } = 1.0f;
    float _time = 0.0f;
    WaitForSeconds _tick { get; set; } = new WaitForSeconds(_tickTime);
    WaitForSeconds _waitLoadingtime { get; set; } = new WaitForSeconds(_startTime);
    WaitForSeconds _waitrealtime { get; set; } = new WaitForSeconds(_customFrame);

    Coroutine _coroutine;


    enum GameObjects
    {
        Black,
        Intro,
    }
    enum Buttons
    {
    }
    enum Texts
    {
        TextProduction
    }
   
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();
        TextAction();

    }

    #region Btn

    void ButtonBind()
    {

    }
    #endregion Btn

   

    #region Txt

    void TextAction()
    {
        _coroutine = StartCoroutine(TextActionCorutine());
    }
    IEnumerator TextActionCorutine()
    {
        yield return _waitLoadingtime;
        while (true)
        {
            yield return _waitrealtime;
            _time += _customFrame;

            GetGameObject((int)GameObjects.Intro).transform.localScale = GetGameObject((int)GameObjects.Intro).transform.localScale + new Vector3(_customFrame * MaskSpeed, _customFrame * MaskSpeed, 0);


            if (_time >= _fadeOutTime)
            {
                GetGameObject((int)GameObjects.Black).SetActive(false);
                GetGameObject((int)GameObjects.Intro).SetActive(false);

                break;
            }

        }

        StringBuilder stringBuilder = new StringBuilder("ㅁ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        
        yield return _tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("모");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;
        
        stringBuilder.Append("ㄷ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;

        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("데");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("뎀");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;


        stringBuilder.Append(" ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;

        stringBuilder.Append("ㅅ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("스");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;

        stringBuilder.Append("ㅍ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("페");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;


        stringBuilder.Append("ㅇ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("이");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;

        stringBuilder.Append("ㅅ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("스");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return _tick;

        yield return new WaitForSeconds (_endTime - (14 * _tickTime)) ;


        //GameManager.Sound.Play(Define.SFX.Intro);


        GameManager.UI.ClosePopupUI(this);


        GameManager.UI.ShowSceneUI<UI_GameScene>();
        GameManager.InGameData.narration = GameManager.UI.ShowSceneUI<Narration>();
        GameManager.InGameData.narration.PlayIntro();

    }


    #endregion Txt

}
