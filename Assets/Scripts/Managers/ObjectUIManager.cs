using UnityEngine;
using System.Collections;

public class ObjectUIManager : MonoBehaviour {
    public GameObject objBox;
    public GameObject cantClick;
    public GameObject pfBall;


    public float speed = 100f;

    // object UI의 상태
    private bool isPop = false;
    private bool isReset = false;
    private int buttonClickCount = 0;
    private float clickTime;

    // 마우스에 눌린 오브젝트
    private GameObject clickedObj;
    private GameObject ball;


    void Awake()
    {
        cantClick.SetActive(false);
        clickTime = 0;
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
        }
        if (isReset)
        {
            if (ball != null)
                ball.GetComponent<BallController>().GameReset();
            cantClick.SetActive(false);
            CloseBox();

            if (buttonClickCount == 2)
            {
                PerfectReset();
            }
            isReset = false;
        }

        // 오브젝트 창
        PopUp();

        // 버튼이 눌렸을 때 시간 카운트
        if( buttonClickCount != 0 )
            clickTime += Time.deltaTime;
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
                objBox.transform.position = new Vector3(-18.8f, 0f, -2.0f);
            else
                objBox.transform.position += new Vector3(Time.deltaTime * (-speed), 0f, 0f);
        }
        else
        {
            // 범위 초과시 포지션 고정
            if(objBox.transform.position.x >= -5.8f)
                objBox.transform.position = new Vector3(-5.8f, 0f, -2.0f);
            else
                objBox.transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
        }
        // ---------------------------------------------------------------------------------
    }

    void CloseBox()
    {
        isPop = false;
    }

    public void SwitchPop()
    {
        isPop = !isPop;
    }
    public void Play()
    {
        // 공이 없으면 새로 만들어줌
        if (ball == null)
            ball = Instantiate(pfBall);
        ball.GetComponent<BallController>().GamePlay();
        cantClick.SetActive(true);
        buttonClickCount = 0;
        CloseBox();
    }

    // 리셋 버튼 클릭 시 공 초기화 + 더블클릭 카운트
    public void Reset()
    {
        isReset = true;

        if (clickTime < 1.5f)
        {
            ++buttonClickCount;
        }        
        else
        {   // 버튼 누르고 1.5초가 지나면 카운트 및 시간 초기화
            clickTime = 0;
            buttonClickCount = 0;
        }
        CloseBox();
    }

    // 더블 클릭 시 실행되며 유저가 만들어둔 오브젝트를 초기화 시킨다.
    public void PerfectReset()
    {
        isReset = true;
        buttonClickCount = 0;
        GetComponent<ObjectManager>().DestroyAllObject();
    }

    public void StageClear()
    {
        isReset = true;
        buttonClickCount = 2;
    }
}
