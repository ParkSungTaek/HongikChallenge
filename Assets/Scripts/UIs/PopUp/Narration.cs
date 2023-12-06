using Client;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Narration : UI_Scene
{

    enum narration
    {
        Intro,
        Outro,
        roomM,
        MaxCount,
    }
    const int MaxSecond = 15;
    WaitForSeconds[] Seconds = new WaitForSeconds[MaxSecond];

    Coroutine[] coroutine = new Coroutine[(int)narration.MaxCount];
    enum GameObjects
    {

    }
    enum Buttons
    {
    }
    enum Texts
    {
        NarrationTxt,
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        ButtonBind();


        for (int i = 1; i < MaxSecond; i++)
        {
            Seconds[i] = new WaitForSeconds((float)i);
        }


    }


    #region Btn
    void ButtonBind()
    {
        //BindEvent(GetButton((int)Buttons.Button).gameObject, DelPopup);
    }

    #endregion Btn


    public void PlayIntro()
    {
        this.gameObject.SetActive(true);
        coroutine[(int)narration.Intro] = StartCoroutine(Intro());
    }
    public void EndIntro()
    {
        if (coroutine[(int)narration.Intro] != null)
        {
            StopCoroutine(coroutine[(int)narration.Intro]);
        }
        
    }


    public void PlayOutro()
    {
        this.gameObject.SetActive(true);

        EndIntro();
        EndroomM();
        coroutine[(int)narration.Outro] = StartCoroutine(Outro());
    }
    public void EndOutro()
    {

        if (coroutine[(int)narration.Outro] != null)
        {
            StopCoroutine(coroutine[(int)narration.Outro]);
        }

    }


    public void PlayroomM()
    {
        this.gameObject.SetActive(true);
        EndIntro();
        coroutine[(int)narration.roomM] = StartCoroutine(roomM());
    }
    public void EndroomM()
    {
        if (coroutine[(int)narration.roomM] != null)
        {
            StopCoroutine(coroutine[(int)narration.roomM]);
        }

    }


    #region 자막 나레이션 싱크

    IEnumerator Intro()
    {
        List<Story> intro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.intro][0];


        GetText((int)Texts.NarrationTxt).text = intro[0].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro1);
        yield return Seconds[2];

        GetText((int)Texts.NarrationTxt).text = intro[1].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro2);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = intro[2].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro3);
        yield return Seconds[7];

        GetText((int)Texts.NarrationTxt).text = intro[3].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro4);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = intro[4].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro5);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = intro[5].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro6);
        yield return Seconds[3];

        GetText((int)Texts.NarrationTxt).text = intro[6].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro7);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = intro[7].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro8);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = intro[8].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro9);
        yield return Seconds[6];

        GetText((int)Texts.NarrationTxt).text = intro[9].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro10);
        yield return Seconds[4];

        GetText((int)Texts.NarrationTxt).text = intro[10].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro11);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = intro[11].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro12);
        yield return Seconds[6];

        GetText((int)Texts.NarrationTxt).text = intro[12].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro13);
        yield return Seconds[3];

        this.gameObject.SetActive(false);


    }
    IEnumerator Outro()
    {
        List<Story> outro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.outro][0];


        GetText((int)Texts.NarrationTxt).text = outro[0].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Outro1);
        yield return Seconds[4];

        GetText((int)Texts.NarrationTxt).text = outro[1].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Outro2);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = outro[2].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Outro3);
        yield return Seconds[6];

        GetText((int)Texts.NarrationTxt).text = outro[3].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Outro4);
        yield return Seconds[5];

        GetText((int)Texts.NarrationTxt).text = outro[4].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Outro5);
        yield return Seconds[4];

        GetText((int)Texts.NarrationTxt).text = outro[5].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Outro6);
        yield return Seconds[4];

        GameManager.UI.ShowPopupUI<UI_Outro>();
        this.gameObject.SetActive(false);


    }
    IEnumerator roomM()
    {
        List<Story> roomM = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.roomM][0];

        GetText((int)Texts.NarrationTxt).text = roomM[0].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.roomM1);
        yield return Seconds[4];

        GetText((int)Texts.NarrationTxt).text = roomM[1].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.roomM2);
        yield return Seconds[7];
        
        GetText((int)Texts.NarrationTxt).text = roomM[2].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.roomM3);
        yield return Seconds[8];
        
        GetText((int)Texts.NarrationTxt).text = roomM[3].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.roomM4);
        yield return Seconds[7];
        
        GetText((int)Texts.NarrationTxt).text = roomM[4].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.roomM5);
        yield return Seconds[6];

        this.gameObject.SetActive(false);
    }

    #endregion
}
