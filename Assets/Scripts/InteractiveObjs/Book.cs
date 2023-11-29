using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : InteractObj
{
    [SerializeField]
    Define.StoryInteractOBJs text;
    protected override void InteractAction()
    {
        GameManager.UI.ShowPopupUI<UI_Bear>().SetText(text);
    }
}
