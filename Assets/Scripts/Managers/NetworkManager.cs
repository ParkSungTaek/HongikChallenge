using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;

//https://console.developers.google.com/

public class NetworkManager
{
    GoogleSheet data;
    // Start is called before the first frame update

    public void Init()
    {
        data = Resources.Load<GoogleSheet>("ScriptableObj/GoogleSheet");
        if (data != null)
        {
            Debug.Log("GET");
            Run();
        }
        else
        {
            Debug.Log("Can't");
        }
    }
    public void Run()
    {
        try{
            UpdateStory(GetStoryData);
            UpdateQuestion(GetQuestionData);

        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            try
            {
                UpdateStory(GetStoryData);
                UpdateQuestion(GetQuestionData);

            }
            catch(Exception ex2)
            {
                Debug.Log(ex2);
            }
        }


    }
    void UpdateStory(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedStoryWorksheet), callback, mergedCells);
    }
    void UpdateQuestion(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedQuestionWorksheet), callback, mergedCells);
    }
    void GetStoryData(GstuSpreadSheet ss)
    {
        int num = ss.rows.secondaryKeyLink.Count - 1;
        try
        {
            for (int idx = 0; idx < num; idx++)
            {
                data.GetStoryData(ss.rows[idx.ToString()]);
            }
        }
        catch
        (Exception e)
        {
            Debug.Log(e);
            return;
        }
        finally
        {
            Debug.Log("StoryFinish");

        }

    }
    void GetQuestionData(GstuSpreadSheet ss)
    {
        int num = ss.rows.secondaryKeyLink.Count - 1;
        GameManager.InGameData.QuestionWrapper.Init(num);
        
        try
        {
            for (int idx = 0; idx < num; idx++)
            {
                data.GetQuestionData(ss.rows[idx.ToString()], idx.ToString());
            }
        }
        catch
        (Exception e)
        {
            return;
        }
        finally
        {
            Debug.Log("QuestionFinish");

        }

    }

}
