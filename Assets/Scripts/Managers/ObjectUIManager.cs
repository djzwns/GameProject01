using UnityEngine;
using System.Collections;

public class ObjectUIManager : MonoBehaviour {
    public GameObject ball;
    public GameObject objBox;


    // object UI의 상태
    private bool isPop = false;
    // 마우스에 눌린 오브젝트
    private GameObject clickedObj;


    void Awake()
    {
    }

    void Update()
    {
        // 마우스가 눌렸다가 때질 때 실행. 괄호의 0은 왼쪽 클릭을 의미
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 위치의 오브젝트를 받아옴
            clickedObj = GetClickedObject();

            // 누르면 팝업 시킴.
            if (clickedObj.Equals(objBox))
            {
                SwitchPop();
            }
            if (clickedObj.name == "play")
            {
                ball.GetComponent<BallController>().MoveBall();
            }
            if (clickedObj.name == "reset")
            {
                ball.GetComponent<BallController>().InitBall();
                GetComponent<ObjectManager>().DestroyAllObject();
            }
        }
    }


    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    private GameObject GetClickedObject()
    {        
        return GetComponent<CameraManager>().GetClickedObject();
    }
    

    public void SwitchPop()
    {
        isPop = !isPop;
        if (!isPop)
        {
            objBox.transform.position = new Vector3(-5.8f, 0f, -0.9f);
        }
        else
        {
            objBox.transform.position = new Vector3(-18.8f, 0f, -0.9f);
        }
    }
}
