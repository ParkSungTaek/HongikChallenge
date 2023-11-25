using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPhysicsController : MonoBehaviour
{
    DoorController doorController;

    private void Start()
    {
        doorController = transform.parent.parent.parent.GetComponent<DoorController>();
        doorController.SetDoorPhysics(this.gameObject);

    }
    private void OnMouseDown()
    {
        doorController.OpenOrClose();
    }
}
