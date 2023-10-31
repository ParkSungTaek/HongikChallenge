using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ4 : InteractObj
{
    protected override void InteractAction()
    {
        GameManager.UI.ShowPopupUI<UI_GetName>();
    }

}
