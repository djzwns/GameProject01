using UnityEngine;
using System.Collections;

public class ObjectUIManager : MonoBehaviour {
    public GameObject pfBall;
    public GameObject objBox;
    public GameObject cantClick;

    GameObject ball;
    int ballCount = 0;

    public float speed = 100f;

    // object UI의 상태
    private bool isPop = false;
    // 마우스에 눌린 오브젝트
    private GameObject clickedObj;


    void Awake()
    {
        cantClick.SetActive(false);
    }

    void Update()
    {
        // 마우스가 눌렸다 떨어졌을 때 실행. 괄호의 0은 왼쪽 클릭을 의미
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 위치의 오브젝트를 받아옴
            clickedObj = GetClickedObject();

            // 박스 누르면 창 띄우거나 접어줌. 오브젝트 클릭시에도 마찬가지
            if (clickedObj.Equals(objBox) || clickedObj.tag == "Preview")
            {
                SwitchPop();
            }

            // 게임 시작버튼 공이 0개일 때만 실행 됨.
            if (clickedObj.name == "play" && ballCount == 0)
            {
                GamePlay();
                CloseBox();
            }

            // 리셋 버튼
            else if (clickedObj.name == "reset")
            {
                GameReset();
                CloseBox();
            }
        }

        // 오브젝트 창
        PopUp();
    }

    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    private GameObject GetClickedObject()
    {        
        return GetComponent<CameraManager>().GetClickedObject();
    }

    private void PopUp()
    {
        // 팝업 상태에 따라 움직여준다.-----------------------------------------------------
        if (!isPop)
        {
            // 범위 초과시 포지션 고정
            if(objBox.transform.position.x <= -18.8f)
                objBox.transform.position = new Vector3(-18.8f, 0f, -0.9f);
            else
                objBox.transform.position += new Vector3(Time.deltaTime * (-speed), 0f, 0f);
        }
        else
        {
            // 범위 초과시 포지션 고정
            if(objBox.transform.position.x >= -5.8f)
                objBox.transform.position = new Vector3(-5.8f, 0f, -0.9f);
            else
                objBox.transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
        }
        // ---------------------------------------------------------------------------------
    }

    // 시작
    private void GamePlay()
    {
        ball = Instantiate(pfBall);
        ++ballCount;

        cantClick.SetActive(true);
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
        cantClick.SetActive(false);
        GetComponent<ObjectManager>().DestroyAllObject();
    }

    void CloseBox()
    {
        isPop = false;
    }

    public void SwitchPop()
    {
        isPop = !isPop;
        //if (!isPop)
        //{
        //    if (objBox.transform.position.x >= -5.8)
        //        objBox.transform.position += new Vector3(-5.8f * Time.deltaTime, 0f, -0.9f);
        //}
        //else
        //{
        //    if (objBox.transform.position.x <= -18.8)
        //        objBox.transform.position += new Vector3(-18.8f * Time.deltaTime, 0f, -0.9f);
        //}
    }
}
