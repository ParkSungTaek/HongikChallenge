using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Production_Text : UI_Popup
{
    const float _tick = 0.35f;
    WaitForSeconds Tick { get; set; } = new WaitForSeconds(_tick);
    Coroutine _coroutine;
    enum GameObjects
    {
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
        StringBuilder stringBuilder = new StringBuilder("ㅅ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        
        yield return Tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("시");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("실");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;
        
        stringBuilder.Append("ㅈ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("재");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Append("ㅇ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("으");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("의");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Append(" ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        stringBuilder.Append("ㅇ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("야");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("양");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Append("ㅌ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("태");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        yield return new WaitForSeconds (5.0f - (14 * _tick)) ;

        GameManager.UI.ClosePopupUI(this);

        
    }


    #endregion Txt

}
