using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_SpeechBubble : MonoBehaviour
{
    SpeechBubble speechBubble;
    // Start is called before the first frame update
    void Start()
    {
        speechBubble = transform.parent.GetComponent<SpeechBubble>();
    }

    private void OnMouseDown()
    {
        Debug.Log("GetRight");
        speechBubble.Btn_Right();
    }


}
