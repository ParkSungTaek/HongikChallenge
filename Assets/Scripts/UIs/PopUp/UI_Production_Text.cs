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
    const float _endTime = 7.0f;
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
        StringBuilder stringBuilder = new StringBuilder("ㅁ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        
        yield return Tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("모");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;
        
        stringBuilder.Append("ㄷ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("데");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("뎀");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Append(" ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        stringBuilder.Append("ㅅ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;
        
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("스");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        stringBuilder.Append("ㅍ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("페");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Append("ㅇ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("이");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        stringBuilder.Append("ㅅ");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;


        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append("스");
        GetText((int)Texts.TextProduction).text = stringBuilder.ToString();
        yield return Tick;

        yield return new WaitForSeconds (_endTime - (14 * _tick)) ;

        GameManager.UI.ClosePopupUI(this);

        
    }


    #endregion Txt

}
