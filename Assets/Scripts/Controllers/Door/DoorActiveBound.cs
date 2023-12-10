using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActiveBound : MonoBehaviour
{
    // Start is called before the first frame update
    DoorController _door;

    public void SetDoor(DoorController door)
    {
        _door = door;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        _door.CanOpen = true;
       
    }
    private void OnTriggerStay(Collider other)
    {
        if(!GameManager.InGameData.IntroPlay && !GameManager.InGameData.IntroPlay)
        {
            GameManager.InGameData.IntroPlay = true;
            GameManager.InGameData.narration.PlayIntro2();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _door.CanOpen = false;
        _door.ExitBound();

    }


}
