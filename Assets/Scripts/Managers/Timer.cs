using UnityEngine;
using System.Collections;
using UnityEngine.UI;   // Text 사용

public class Timer : MonoBehaviour {
    // 열리고 닫히는 시간 -----------
    public float openTime;
    public float closeTime;
    // ------------------------------

    public GameObject endPoint;     // 개방 될 문임
    public AudioSource openSound;   // 문 열릴 때 소리

    // 그래픽으로 시간의 흐름을 보여줌 -----------------------------------
    public Scrollbar openTimer;     // 오픈 타이머
    public Scrollbar currentTimer;  // 현재 시간 타이머

    public Text openTimeText;    // 개방시간을 출력해줄 gui text
    public Text currentTimeText; // 시간을 출력해줄 gui text
    public Text timeCycleText;   // 몇 번 초과 됐는지 출력
    // -------------------------------------------------------------------

    float currentTime;           // 현재 시간
    int timeCycle;               // 시간 초과된 횟수
    bool soundPlay;              // 소리 재생되고 있는지.
    
    // Start함수, 모든 Awake함수의 호출 뒤에 실행 되는 함수로 호출 순서에 주의 해야함..
    // 왜 쓰는지도 모르고 Awake만 쓰다가 이 일을 계기로 어마어마한 발견을 했다.
	void  Start()
    {
        Init();
        soundPlay = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 게임에 공이 생기면 카운트 시작.
        if (GameObject.FindWithTag("Ball") != null)
        {
            CountTime();
        }
        else
        {
            InitTime();
        }
	}

    // 시간을 카운트 한다.
    void CountTime()
    {
        currentTime += Time.deltaTime;                           // 현재 시간 저장
        currentTimeText.text = "현재 시간 : " + currentTime;

        currentTimer.value = currentTime / closeTime;            // 0~1의 값을 갖게 나눠줌

        // 열리는 시간 ~ 닫히는 시간 사이에 있으면 종료점 활성화
        if (openTime <= currentTime && currentTime <= closeTime)
        {
            endPoint.SetActive(true);
            if (!soundPlay)
            {
                openSound.Play();
                soundPlay = true;
            }
        }
        else
        {
            endPoint.SetActive(false);
            soundPlay = false;

        }

        // 시간이 초과되면 타임사이클 1회 증가시키고 리셋
        if (currentTimer.value >= 1)
        {
            ++timeCycle;
            timeCycleText.text = "초과된 횟수 : " + timeCycle;
            ResetTime();
        }
    }

    // 현재 시간 초기화
    void ResetTime()
    {
        currentTime = 0;
        currentTimeText.text = "현재 시간 : 0";
        currentTimer.value = 0;
    }

    // 완전 초기화 시킴
    void InitTime()
    {
        currentTime = 0;
        currentTimeText.text = "현재 시간 : 0";
        currentTimer.value = 0;

        timeCycle = 0;
        timeCycleText.text = "초과된 횟수 : 0";

        endPoint.SetActive(true);
    }

    void Init()
    {
        // endPoint 를 받아와 열리는 시간과 닫히는 시간에 대한 정보를 받아온다 -----
        endPoint = GameObject.Find("EndPoint");
        openTime = endPoint.GetComponent<EndPointTime>().GetOpenTime();
        closeTime = endPoint.GetComponent<EndPointTime>().GetCloseTime();
        // -------------------------------------------------------------------------

        // 기본 적인 스테이지 정보로 개방 시간을 출력해줌.
        openTimeText.text = "개방 시간 : " + openTime + " ~ " + closeTime;
        openTimer.value = openTime / closeTime;  // 시간 비율로 사이즈 잡아줌.
    }

    // 스테이지 전환하면서 초기화 시킬 때 사용
    public void Init(GameObject stage)
    {
        endPoint = GameObject.Find("EndPoint");
        EndPointTime endpoint;
        // endPoint 를 받아와 열리는 시간과 닫히는 시간에 대한 정보를 받아온다 -----
        endpoint = stage.GetComponentInChildren<EndPointTime>();
        openTime = endpoint.GetOpenTime();
        closeTime = endpoint.GetCloseTime();
        // -------------------------------------------------------------------------

        // 기본 적인 스테이지 정보로 개방 시간을 출력해줌.
        openTimeText.text = "개방 시간 : " + openTime + " ~ " + closeTime;
        openTimer.value = openTime / closeTime;  // 시간 비율로 사이즈 잡아줌.
    }

}
