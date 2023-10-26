using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ2 : InteractObj
{
    [SerializeField]
    GameObject speechBubble;
    const float _inactive = 3.0f;
    WaitForSeconds Wait = new WaitForSeconds(_inactive);
    protected override void InteractAction()
    {
        if(!speechBubble.activeSelf) {
            speechBubble.SetActive(true);
            StartCoroutine(Inactive());
        }
    }

    IEnumerator Inactive()
    {
        yield return Wait;
        speechBubble.SetActive(false);

    }
}
