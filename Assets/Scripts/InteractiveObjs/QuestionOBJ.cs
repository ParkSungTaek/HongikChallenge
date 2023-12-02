using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionOBJ : InteractObj
{

    enum Children
    {
        speechBubbleText,
        Left,
        Right,
        MaxCount,
    }


    int textIDX = 0;
    int MaxIIDX = 100;
    const int Scenario = 0;
    List<Story> ScenarioList = new List<Story>();
    Define.StoryInteractOBJs BearType;
    TMP_Text speechBubbleTxt;

    GameObject[] _go = new GameObject[(int)Children.MaxCount];


    public void OpenSpeechBubble(Define.StoryInteractOBJs text)
    {
        gameObject.SetActive(true);
        if (_go[0] == null)
        {
            for (int i = 0; i < (int)Children.MaxCount; i++)
            {
                _go[i] = transform.GetChild(i).gameObject;
                Debug.Log($"{(Children)i}'s Name {_go[i].name}");
            }

            speechBubbleTxt = _go[(int)Children.speechBubbleText].GetComponent<TMP_Text>();
        }

        textIDX = 0;
        SetText(text);
        ShowText();
    }
    private void OnEnable()
    {
        textIDX = 0;
    }

    public void SetText(Define.StoryInteractOBJs text)
    {
        BearType = text;
        MaxIIDX = GameManager.InGameData.StoryWrapper[BearType][Scenario].Count - 1;
        ScenarioList = GameManager.InGameData.StoryWrapper[BearType][Scenario];
        ShowText();
    }
    void ShowText()
    {
        speechBubbleTxt.text = ScenarioList[textIDX].Script;
        LeftRightActiveControl();
    }


    void LeftRightActiveControl()
    {
        if (textIDX <= 0)
        {
            _go[(int)Children.Left].SetActive(false);
        }
        else
        {
            _go[(int)Children.Left].SetActive(true);

        }
        if (textIDX >= MaxIIDX)
        {
            //_go[(int)Children.Right].SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            _go[(int)Children.Right].SetActive(true);
        }
    }


    #region Btn

    public void Btn_Right()
    {
        textIDX++;
        ShowText();
    }
    public void Btn_Left()
    {
        textIDX--;
        ShowText();
    }

    protected override void InteractAction()
    {
        throw new System.NotImplementedException();
    }

    #endregion Btn


}