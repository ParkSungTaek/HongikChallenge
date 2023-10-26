using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ1 : InteractObj
{
    protected override void InteractAction()
    {
        GameManager.UI.ShowPopupUI<UI_OBJ1>();
    }
}
