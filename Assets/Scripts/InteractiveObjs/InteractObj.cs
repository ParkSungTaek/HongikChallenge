using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObj : MonoBehaviour
{
    [SerializeField]
    public Define.Field InteractField;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        InteractAction();
    }
    protected abstract void InteractAction();
}
