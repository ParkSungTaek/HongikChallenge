using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPhysicsController : MonoBehaviour
{
    DoorController doorController;

    private void Start()
    {
        doorController = transform.parent.GetComponent<DoorController>();
    }
    private void OnMouseDown()
    {
        doorController.OpenOrClose();
    }
}
