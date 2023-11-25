using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField]
    PlayableController.WallDetectorEnum controller = PlayableController.WallDetectorEnum.Front;

    [SerializeField]
    LayerMask interactableLayer;
    public bool Detecting = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (interactableLayer == (1 << other.gameObject.layer)) // Ư�� ���̾�� �浹�ߴ��� Ȯ��
        {
            Detecting = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (interactableLayer == (1 << other.gameObject.layer)) // Ư�� ���̾�� �浹�ߴ��� Ȯ��
        {
            Detecting = false;
        }
    }

}
