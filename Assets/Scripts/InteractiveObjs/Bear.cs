using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : InteractObj
{
    SpeechBubble speechBubble;
    [SerializeField]
    Define.StoryInteractOBJs text;
   
    protected override void InteractAction()
    {
        if (speechBubble == null)
        {
            speechBubble = transform.Find("SpeechBubble").GetComponent<SpeechBubble>();
        }
        if (!speechBubble.gameObject.activeSelf)
        {
            speechBubble.OpenSpeechBubble(text);
            
        }
    }

}
