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
                    Debug.LogError($"Story Obj Parse ���� {tmp[(int)StoryCell.Obj]} ó�� �� �Ǿ��ִ��� Ȯ�� �ٶ�");
                    return;
                }
                int Scenario = 0;
                if (!int.TryParse(tmp[(int)StoryCell.Scenario], out Scenario))
                {
                    Debug.LogError($"Story Scenario Parse ���� {tmp[(int)StoryCell.Scenario]} ó�� �� �Ǿ��ִ��� Ȯ�� �ٶ�");
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
                            Debug.LogError($"������ �ִ� To --{tmp[(int)StoryCell.To]}--");

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

            }
            catch
            {
                Debug.LogError($"���� �ִ� OBJ {tmp[(int)StoryCell.Obj]}");

                if (tmp[(int)StoryCell.To] == null)
                {
                    Debug.LogError($"tmp[(int)StoryCell.To] == null");

                }
            }
        }




    }
    internal void GetQuestionData(string line)
    {

        string[] tmp = line.Split('\t');

        try
        {
            Question tmpQuestion = new Question();
            

            tmpQuestion.Q1 = tmp[(int)QuestionCell.Q1];
            tmpQuestion.Q2 = tmp[(int)QuestionCell.Q2];


            tmpQuestion.A1 = int.Parse(tmp[(int)QuestionCell.A1]);
            tmpQuestion.A2 = int.Parse(tmp[(int)QuestionCell.A2]);


            GameManager.InGameData.QuestionWrapper.Add(tmpQuestion);


#if UNITY_EDITOR
            Debug.Log("�� �尨");
#endif

        }
        catch
        {
            Debug.Log($"Question {tmp[(int)QuestionCell.IDX]} �� �������� ");
        }

    }
}
