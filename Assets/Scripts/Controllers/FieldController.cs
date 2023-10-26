using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Define.Field ThisField;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.InGameData.MyField = ThisField;
    }




}
