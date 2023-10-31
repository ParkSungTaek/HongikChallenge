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

    string QuestionIDX { get; set; } = "";
    internal void GetStoryData(List<GSTU_Cell> list)
    {

        //string name = "성택";
        //string tmp = "안녕내이름은 {name} 야";
        //Debug.Log($"{tmp}");
        //tmp.Replace("{name}", name);


        StoryWrapper answer = GameManager.InGameData.StoryWrapper;

        Define.StoryInteractOBJs _type = Define.StoryInteractOBJs.Ball;
        Story tmpStory = new Story();
        bool Empty = false;
        int Scenario = 0;


        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "Obj":
                    {
                        if (list[i].value == "")
                        {
                            Empty = true;
                            return;
                        }
                        Enum.TryParse(list[i].value, out _type);
                     
                        break;
                    }
                case "Scenario":
                    {
                        Scenario = int.Parse(list[i].value);
                        break;
                    }
                case "Script":
                    {
                        tmpStory.Script = list[i].value;
                        break;

                    }

                case "Action":
                    {
                        if (list[i].value != "" || list[i].value != null)
                        {
                            Define.ActionData actionData;
                            Enum.TryParse(list[i].value, out actionData);
                            tmpStory.Action = actionData;
                        }
                        else
                        {
                            tmpStory.Action = Define.ActionData.None;
                        }
                        break;


                    }
                case "To":
                    {
                        if (list[i].value != "" || list[i].value != null)
                        {
                            tmpStory.To = int.Parse(list[i].value);
                        }
                        else
                        {
                            tmpStory.To = -1;
                        }
                        
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
            if(!answer[_type].ContainsKey(Scenario))
            {
                answer[_type][Scenario] = new List<Story>();
            }
            answer[_type][Scenario].Add(tmpStory);
#if UNITY_EDITOR
            Debug.Log($"Scenario {Scenario}, Script {tmpStory.Script}, Action {tmpStory.Action}, To {tmpStory.To}");
#endif
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
