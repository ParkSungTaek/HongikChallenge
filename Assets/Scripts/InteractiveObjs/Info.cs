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
        if (_Script == Define.StoryInteractOBJs.CuratingM || _Script == Define.StoryInteractOBJs.CuratingY)
        {
            GameManager.UI.ShowPopupUI<UI_Info>().SetText(_Name, _info0, _info1, _Script);
        }
        else if(_Script != Define.StoryInteractOBJs.book2)
        {
            GameManager.UI.ShowPopupUI<UI_RealBook>().SetText(_Name, _info0, _info1, _Script);

        } 
        else
        {
            GameManager.UI.ShowPopupUI<UI_Book2>();

        }
    }
}
