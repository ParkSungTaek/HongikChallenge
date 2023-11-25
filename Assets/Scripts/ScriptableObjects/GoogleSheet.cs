using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;
using Client;
using static Define;

[CreateAssetMenu(fileName = "GoogleSheet", menuName = "ScriptableObject/GoogleSheet", order = int.MaxValue)]

public class GoogleSheet : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedStoryWorksheet = "";
    public string associatedQuestionWorksheet = "";

    enum StoryCell
    {
        IDX,
        Obj,
        Scenario,
        Script,
        Action,
        To,
    }
    enum QuestionCell
    {
        IDX,
        Q1,
        Q2,  
        Q3, 
        A1,  
        A2,
        A3,
    }
    string QuestionIDX { get; set; } = "";
   
    internal void GetStoryData(string line)
    {
        
        string[] tmp = line.Split('\t');


        if (tmp[(int)StoryCell.Obj] != "")
        {
            try
            {
                StoryWrapper answer = GameManager.InGameData.StoryWrapper;

                Define.StoryInteractOBJs _type = Define.StoryInteractOBJs.Ball;
                Story tmpStory = new Story();


                if (!Enum.TryParse(tmp[(int)StoryCell.Obj], out _type))
                {
                    Debug.LogError($"Story Obj Parse 실패 {tmp[(int)StoryCell.Obj]} 처리 잘 되어있는지 확인 바람");
                    return;
                }
                int Scenario = 0;
                if (!int.TryParse(tmp[(int)StoryCell.Scenario], out Scenario))
                {
                    Debug.LogError($"Story Scenario Parse 실패 {tmp[(int)StoryCell.Scenario]} 처리 잘 되어있는지 확인 바람");
                }

                tmpStory.Script = tmp[(int)StoryCell.Script];


                
                if (tmp.Length > (int)StoryCell.Action)
                {

                    Define.ActionData actionData;
                    if (Enum.TryParse(tmp[(int)StoryCell.Action], out actionData))
                    {
                        tmpStory.Action = actionData;
                    }
                    else
                    {
                        tmpStory.Action = Define.ActionData.None;
                    }

                    if (tmp[(int)StoryCell.To] != "" && tmp[(int)StoryCell.To][0] != 13)
                    {
                        if (!int.TryParse(tmp[(int)StoryCell.To], out tmpStory.To))
                        {
                            Debug.LogError($"문제가 있는 To --{tmp[(int)StoryCell.To]}--");

                        }
                    }

                    
                }
                else
                {
                    tmpStory.Action = Define.ActionData.None;

                }

                if (!answer[_type].ContainsKey(Scenario))
                {
                    answer[_type][Scenario] = new List<Story>();
                }

                answer[_type][Scenario].Add(tmpStory);
#if UNITY_EDITOR
                Debug.Log("잘 드감");
#endif

            }
            catch
            {
                Debug.LogError($"문제 있는 OBJ {tmp[(int)StoryCell.Obj]}");

                if (tmp[(int)StoryCell.To] == null)
                {
                    Debug.LogError($"tmp[(int)StoryCell.To] == null");

                }
            }
        }




    }
    internal void GetQuestionData(List<GSTU_Cell> list, string QuestionIDX)
    {

        QuestionWrapper answer = GameManager.InGameData.QuestionWrapper;

        int _type = 0;
        Question tmpQuestion = new Question();
        bool Empty = false;
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "IDX":
                    {
                        if (list[i].value == "")
                        {
                            Empty = true;
                            return;
                        }
                        _type = int.Parse(list[i].value);
                        break;
                    }
                case "Q1":
                    {
                        if (list[i].value != "")
                        {
                            tmpQuestion.Q1 = list[i].value;
                        }
                        break;
                    }
                case "Q2":
                    {
                        if (list[i].value != "")
                            tmpQuestion.Q2 = list[i].value;
                        break;

                    }

                case "Q3":
                    {
                        if (list[i].value != "")
                            tmpQuestion.Q3 = list[i].value;
                        break;

                    }

                case "A1":
                    {
                        if (list[i].value != "")
                            tmpQuestion.A1 = int.Parse(list[i].value);
                        break;
                    }
                case "A2":
                    {
                        if (list[i].value != "")
                            tmpQuestion.A2 = int.Parse(list[i].value);
                        break;

                    }

                case "A3":
                    {
                        if (list[i].value != "")
                            tmpQuestion.A3 = int.Parse(list[i].value);
                        break;

                    }
                default:
                    {
                        break;
                    }
            }
        }
        
        if (!Empty)
        {
            answer[_type] = tmpQuestion;
#if UNITY_EDITOR
            Debug.Log($"IDX {_type}, Q1 {tmpQuestion.Q1}, Q2 {tmpQuestion.Q2}, Q3 {tmpQuestion.Q3}, A1 {tmpQuestion.A1}, Q2 {tmpQuestion.A2}, Q3 {tmpQuestion.A3}");
#endif
        }
    }
}
