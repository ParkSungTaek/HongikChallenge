using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class EarthController : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 10f; // ȸ�� �ӵ�

    [SerializeField]
    Define.Earths earth; // ȸ�� �ӵ�

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.InGameData.Earths[(int)earth] = this.gameObject;
        if(earth != Earths.defaultVariant)
        {
            this.gameObject.SetActive(false);
        }
    }

}
