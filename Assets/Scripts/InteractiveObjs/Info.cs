using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : InteractObj
{
    [SerializeField]
    Define.StoryInteractOBJs _Name;
    [SerializeField]
    Define.StoryInteractOBJs _info0;
    [SerializeField]
    Define.StoryInteractOBJs _info1;
    [SerializeField] 
    Define.StoryInteractOBJs _Script;

    protected override void InteractAction()
    {
        GameManager.UI.ShowPopupUI<UI_Info>().SetText(_Name,_info0, _info1,_Script);
    }
}
