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
        ////마우스 커서 보이지 않게함
        //Cursor.visible = true;
        //this.vis = true;
        //
        //CursorFalse();
    }
    public void CursorTrue()
    {
        Cursor.lockState = CursorLockMode.None;
        // 마우스 커서 보이게 함
        Cursor.visible = true;
        this.vis = true;
    }
    public void CursorFalse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //마우스 커서 보이지 않게함
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
                //// 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
                //float YRotateSize = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

                float XRotateSize = touch.deltaPosition.x * turnSpeed * Time.deltaTime;

                // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)

                float YRotateSize = touch.deltaPosition.y * turnSpeed * Time.deltaTime;


                //Debug.Log(Time.deltaTime);
                xRotate -= YRotateSize;
                // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
                xRotate = Mathf.Clamp(xRotate, -70, 80);
                //시점이 망가지는것을 방지해서 카메라는 X축만 
                transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
                // Y축 회전은 Player에서
                Body.transform.Rotate(Vector3.up * XRotateSize);

            }
        }
#elif UNITY_EDITOR             
        /// UI 와 상호작용 중이 아니라면
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            float XRotateSize = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
            // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
            float YRotateSize = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
            xRotate -= YRotateSize;
            // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
            xRotate = Mathf.Clamp(xRotate, -70, 80);
            //시점이 망가지는것을 방지해서 카메라는 X축만 
            transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
            // Y축 회전은 Player에서
            Body.transform.Rotate(Vector3.up * XRotateSize);

        }

#endif


    }
}
