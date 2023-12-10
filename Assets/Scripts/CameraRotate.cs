using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotate : MonoBehaviour
{
    float turnSpeed;
    private Vector3 initialMousePosition;
    private float xRotate = 0.0f;
    bool vis = true;
    GameObject Body;
    private void Start()
    {
#if UNITY_EDITOR
        turnSpeed = 720f;
#elif UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
        turnSpeed = 8f;
#endif

        Application.targetFrameRate = 60;
        Body = transform.parent.gameObject;
        //Cursor.lockState = CursorLockMode.None;
        ////���콺 Ŀ�� ������ �ʰ���
        //Cursor.visible = true;
        //this.vis = true;
        //
        //CursorFalse();
    }
    public void CursorTrue()
    {
        Cursor.lockState = CursorLockMode.None;
        // ���콺 Ŀ�� ���̰� ��
        Cursor.visible = true;
        this.vis = true;
    }
    public void CursorFalse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //���콺 Ŀ�� ������ �ʰ���
        Cursor.visible = false;
        this.vis = false;
    }
    void Update()

    {

#if UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
        foreach (Touch touch in Input.touches)
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                //float XRotateSize = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
                //// ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
                //float YRotateSize = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

                float XRotateSize = touch.deltaPosition.x * turnSpeed * Time.deltaTime;

                // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)

                float YRotateSize = touch.deltaPosition.y * turnSpeed * Time.deltaTime;


                //Debug.Log(Time.deltaTime);
                xRotate -= YRotateSize;
                // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
                xRotate = Mathf.Clamp(xRotate, -70, 80);
                //������ �������°��� �����ؼ� ī�޶�� X�ุ 
                transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
                // Y�� ȸ���� Player����
                Body.transform.Rotate(Vector3.up * XRotateSize);

            }
        }
#elif UNITY_EDITOR             
        /// UI �� ��ȣ�ۿ� ���� �ƴ϶��
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            float XRotateSize = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
            // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
            float YRotateSize = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
            xRotate -= YRotateSize;
            // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
            xRotate = Mathf.Clamp(xRotate, -70, 80);
            //������ �������°��� �����ؼ� ī�޶�� X�ุ 
            transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
            // Y�� ȸ���� Player����
            Body.transform.Rotate(Vector3.up * XRotateSize);

        }

#endif


    }
}
