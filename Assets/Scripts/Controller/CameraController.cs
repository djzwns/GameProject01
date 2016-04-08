using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    GameObject ball = null;
    
    Vector3 ballPos;
    Vector3 zPos = new Vector3(0f, 0f, -10f);
    
    public Camera cam;
    public float smooth = 5f;

    // 카메라 움직임 제한을 두기 위한 변수들.
    public float LeftX     = -5.69f;
    public float RightX    = 5.69f;
    public float BottomY   = -3.18f;
    public float TopY      = 3.18f;
    
	// Update is called once per frame
	void Update ()
    {
        if (ball == null)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
        }
        else
            cam.enabled = true;

    }

    // 업데이트 뒤에 실행되는 업데이트 함수로 카메라의 움직임이 자연스러워 진다고 함.
    void LateUpdate()
    {
        // 구슬이 있을 때만 움직임
        if (ball != null)
        {
            ballPos = ball.transform.position + zPos;
            cam.transform.position = Vector3.Lerp(cam.transform.position, ballPos, smooth * Time.deltaTime);
            MoveCameraLimit();
        }
        else
        {
            cam.enabled = false;
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
