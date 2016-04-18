using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    
    Vector3 ballPos;
    Vector3 objPos;
    Vector3 zPos = new Vector3(0f, 0f, -10f);
    public GameObject userObject;
    ObjectController objController;
    
    public Camera cam;
    public float smooth = 5f;

    // 카메라 움직임 제한을 두기 위한 변수들.
    public float LeftX     = -7.48f;
    public float RightX    = 7.48f;
    public float BottomY   = -4.2f;
    public float TopY      = 4.2f;
    
	// Update is called once per frame
	void Update ()
    {
        if (ball.activeSelf == false && userObject == null)
        {
            //userObject = GameObject.FindGameObjectWithTag("UserObject");
            //if (userObject != null)
            //    objController = userObject.GetComponentInChildren<ObjectController>();
        }
        else
        {
            cam.enabled = true;
        }
        if (userObject != null)
        {
            cam.enabled = true;
            objController = userObject.GetComponentInChildren<ObjectController>();
        }

        //if (ball != null || (userObject != null && !userObject.GetComponent<ObjectController>().IsDrop()))
        //{
        //}
        //else
        //{
        //    userObject = null;
        //    cam.enabled = false;
        //}

    }

    // 업데이트 뒤에 실행되는 업데이트 함수로 카메라의 움직임이 자연스러워 진다고 함.
    void LateUpdate()
    {
        // 구슬이나 내려놓지 않은 오브젝트가 있을 때만 움직임
        if (ball.activeSelf == true || (userObject != null && !objController.IsDrop()))
        {
            if (ball.activeSelf == true)
            {
                ballPos = ball.transform.position + zPos;
                cam.transform.position = Vector3.Lerp(cam.transform.position, ballPos, smooth * Time.deltaTime);
                MoveCameraLimit();
            }
            if (!objController.IsDrop())
            {
                objPos = objController.transform.position + zPos;
                cam.transform.position = Vector3.Lerp(cam.transform.position, objPos, smooth * Time.deltaTime);
                MoveCameraLimit();
            }
            
        }
        else
        {
            cam.enabled = false;
            userObject = null;
            objController = null;
        }
    }

    // 카메라의 움직임에 제한을 둔다.
    void MoveCameraLimit()
    {
        Vector3 tempPos;
        tempPos.x = Mathf.Clamp(cam.transform.position.x, LeftX, RightX);
        tempPos.y = Mathf.Clamp(cam.transform.position.y, BottomY, TopY);
        tempPos.z = -10f;

        cam.transform.position = tempPos;
    }
}
