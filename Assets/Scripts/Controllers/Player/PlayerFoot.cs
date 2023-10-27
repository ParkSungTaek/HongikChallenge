using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    PlayableController MyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = transform.parent.GetComponent<PlayableController>();
    }


    private void OnTriggerEnter(Collider other)
    {

        MyPlayer.CanJump = true;
    }

}
