using Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Narration : UI_Scene
{
    Queue<Action> _jobQueue = new Queue<Action>();
    
    bool _isRunning = false;
    enum narration
    {
        Intro1,
        Intro2,
        Intro3,
        Intro4,
        Intro5,
        Outro1,
        Outro2,
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

    #region NarrationPlayEnd
    void PlayNarration()
    {
        _isRunning = true;
        Action action = _jobQueue.Dequeue();
        action.Invoke();
    }
    void EndNarration()
    {
        _isRunning = false;
        this.gameObject.SetActive(false);

    }

    void NextStep()
    {
        if (_jobQueue.Count == 0)
        {
            EndNarration();
        }
        else
        {
            PlayNarration();
        }
    }
    #endregion

    #region Play
    public void PlayIntro1()
    {
        this.gameObject.SetActive(true);
        
        _jobQueue.Enqueue(() => StartCoroutine(Intro1()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }
    
    public void PlayIntro2()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(Intro2()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }
    

    public void PlayIntro3()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(Intro3()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }
    public void PlayIntro4()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(Intro4()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }
    public void PlayIntro5()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(Intro5()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }


    public void PlayOutro1()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(Outro1()));
        GameManager.InGameData.EndDoor.OpenSequence();
        if (!_isRunning)
        {
            PlayNarration();
        }
    }

    public void PlayOutro2()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(Outro2()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }


    public void PlayroomM()
    {
        this.gameObject.SetActive(true);
        _jobQueue.Enqueue(() => StartCoroutine(roomM()));
        if (!_isRunning)
        {
            PlayNarration();
        }
    }
    #endregion Play

    #region 자막 나레이션 싱크

    IEnumerator Intro1()
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

        GameManager.InGameData.CanOpenDoor = true;

        NextStep();

    }

    IEnumerator Intro2()
    {
        List<Story> intro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.intro][0];

        GetText((int)Texts.NarrationTxt).text = intro[6].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro7);
        yield return Seconds[5];

        NextStep();
    }
    IEnumerator Intro3()    {

        List<Story> intro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.intro][0];
        GetText((int)Texts.NarrationTxt).text = intro[7].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro8);
        yield return Seconds[5];

        NextStep();
    }
    IEnumerator Intro4()
    {

        List<Story> intro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.intro][0];

        GetText((int)Texts.NarrationTxt).text = intro[8].Script.Replace("/n", "\n");
        GameManager.Sound.Play(Define.SFX.Intro9);
        yield return Seconds[6];

        NextStep();
    }
    IEnumerator Intro5()
    {

        List<Story> intro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.intro][0];
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

        NextStep();


    }
    IEnumerator Outro1()
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

        NextStep();

    }
    IEnumerator Outro2()
    {
        List<Story> outro = GameManager.InGameData.StoryWrapper[Define.StoryInteractOBJs.outro][0];

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
      

        NextStep();

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
        yield return new WaitForSeconds(6.8f);


        NextStep();
    }

    #endregion
}
