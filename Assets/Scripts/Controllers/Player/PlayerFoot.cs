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
        if(!MyPlayer.CanJump )
            GameManager.Sound.Play(Define.SFX.sfx_jumpLand);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisoin");

    }

}
