using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Curating : InteractObj
{
    [SerializeField]
    Define.StoryInteractOBJs text;
    
    protected override void InteractAction()
    {
        GameManager.UI.ShowPopupUI<UI_Curating>().SetText(text);
        
    }
}
