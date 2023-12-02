using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractObj : MonoBehaviour
{
    [SerializeField]
    public Define.Field InteractField;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            
            InteractAction();
        }
    }
    protected abstract void InteractAction();
}
