using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update

    DoorActiveBound _myBound;
    public bool CanOpen { get; set; } = false;  

      
    void Start()
    {
        _myBound = transform.Find("DoorActiveBound").GetComponent<DoorActiveBound>();
        _myBound.SetDoor(this);
    }

    private void OnMouseDown()
    {
        if (CanOpen)
        {
            

        }
    }
}
