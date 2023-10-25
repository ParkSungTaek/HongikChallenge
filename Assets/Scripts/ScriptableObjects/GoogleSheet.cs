using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;
using Client;

[CreateAssetMenu(fileName = "AnswerSheet", menuName = "Scriptable Object/AnswerSheet", order = int.MaxValue)]

public class GoogleSheet : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    //static string AnswerIDX;
    //string Gender;
    //string QuestionIDX = "";
    internal void UpdateStats(List<GSTU_Cell> list, string QuestionIDX)
    {
        /*
        InGameDataManager.Answer answer = new InGameDataManager.Answer();
        bool Empty = false;
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "QuestionIDX":
                    {
                        if (!GameManager.InGameData.AnswerDictionary.ContainsKey(list[i].value))
                        {
                            GameManager.InGameData.AnswerDictionary[list[i].value] = new Dictionary<string, List<InGameDataManager.Answer>>();
                            if (list[i].value != "")
                            {
                                QuestionIDX = list[i].value;

                            }
                        }
                        break;
                    }
                case "AnswerIDX":
                    {
                        if (list[i].value != "")
                        {
                            AnswerIDX = list[i].value;
                            if (!GameManager.InGameData.AnswerDictionary[QuestionIDX].ContainsKey(AnswerIDX))
                            {
                                GameManager.InGameData.AnswerDictionary[QuestionIDX][AnswerIDX] = new List<InGameDataManager.Answer>();
                            }
                        }
                        break;
                    }
                case "Gender":
                    {
                        if (list[i].value != "")
                        {

                            Gender = list[i].value;

                        }
                        answer.Gender = Gender;
                        break;

                    }

                case "Face":
                    {
                        answer.Face = list[i].value;
                        break;

                    }
                case "Person":
                    {
                        answer.Person = list[i].value;
                        break;

                    }
                case "Script":
                    {
                        if (list[i].value == "")
                        {
                            Empty = true;
                        }
                        else
                        {
                            answer.Script = list[i].value;
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
            GameManager.InGameData.AnswerDictionary[QuestionIDX][AnswerIDX].Add(answer);
#if UNITY_EDITOR
            Debug.Log($"QuestionIDX : {QuestionIDX}, AnswerIDX: {AnswerIDX}, ListCount {GameManager.InGameData.AnswerDictionary[QuestionIDX][AnswerIDX].Count}, Gender : {answer.Gender}, Person : {answer.Person}, Face : {answer.Face}, Script : {answer.Script}");
#endif
        }
        
        */
    }

}
