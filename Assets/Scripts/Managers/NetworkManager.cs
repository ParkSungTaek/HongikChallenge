using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;
using UnityEngine.Networking;
using System.Text;

//https://console.developers.google.com/

public class NetworkManager
{
    public GoogleSheet data { get; private set; }
    // Start is called before the first frame update

    public void Init()
    {
        data = Resources.Load<GoogleSheet>("ScriptableObj/GoogleSheet");
    }

    /// <summary>
    /// ���� �������� ��Ʈ �� �޾ƿ� �����ϴ� �Լ�
    /// </summary>
    /// <param name="GoogleSheetsID"> ���� �������� ��Ʈ�� ID</param>
    /// <param name="ManufactureData"> �������� ��Ʈ ���� �Լ� input�� �� �� �� �޾ƾ���, Cell�� ��('\t')���� ����</param>
    /// <param name="WorkSheetsID"> ��Ʈ�� WorkSheet ���� default �� 0 ù ��</param>
    /// <param name="startCell"> ���� �� default A1</param>
    /// <param name="endCell"> �� �� default E </param>
    /// <returns></returns>
    public IEnumerator RequestAndSetItemDatas(string GoogleSheetsID, Action<string> ManufactureData, string WorkSheetsID = "0", string endCell = "Z", string startCell = "A2")
    {
        
        StringBuilder sb = new StringBuilder();
        sb.Append("https://docs.google.com/spreadsheets/d/");
        sb.Append(GoogleSheetsID);
        sb.Append("/export?format=tsv");
        sb.Append("&gid="+WorkSheetsID);
        sb.Append("&range=" + startCell + ":" + endCell);

        using (UnityWebRequest webData = UnityWebRequest.Get(sb.ToString()))
        {
            
            yield return webData.SendWebRequest();

#if UNITY_EDITOR
            //Debug.Log(webData.downloadHandler.text);
#endif
            string[] dataLines = webData.downloadHandler.text.Split('\n');
            Action[] ManufactureDatas = new Action[dataLines.Length];
            for (int i = 0; i< dataLines.Length; i++)
            {
                ManufactureData(dataLines[i]);
            }


        }

    }


    #region ManufactureData

    public void ManufactureStoryData(string data)
    {

        string[] tmp = data.Split('\t');

        Debug.Log($"{tmp[0]} {tmp[1]} {tmp[2]} {tmp[3]} {tmp[4]}");


    }
    #endregion





}
