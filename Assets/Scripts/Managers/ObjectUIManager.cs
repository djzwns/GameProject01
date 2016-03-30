using UnityEngine;
using System.Collections;

public class ObjectUIManager : MonoBehaviour {
    public GameObject pfBall;
    public GameObject objBox;

    GameObject ball;
    int ballCount = 0;


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

            // 박스 누르면 팝업 시킴.
            if (clickedObj.Equals(objBox))
            {
                SwitchPop();
            }

            // 게임 시작버튼 공이 0개일 때만 실행 됨.
            if (clickedObj.name == "play" && ballCount == 0)
            {
                GamePlay();
            }

            // 리셋 버튼
            else if (clickedObj.name == "reset")
            {
                GameReset();
            }
        }
    }


    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    private GameObject GetClickedObject()
    {        
        return GetComponent<CameraManager>().GetClickedObject();
    }

    // 시작
    private void GamePlay()
    {
        ball = Instantiate(pfBall);
        ++ballCount;
        //ball.GetComponent<BallController>().MoveBall();
    }

    // 리셋
    private void GameReset()
    {
        // 공이 1개 일때 파괴 후 카운트 감소
        if (ballCount == 1)
        {
            ball.GetComponent<BallController>().Reset();
            Destroy(ball);
            --ballCount;
        }
        GetComponent<ObjectManager>().DestroyAllObject();
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
