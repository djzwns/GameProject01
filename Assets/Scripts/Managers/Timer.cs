using UnityEngine;
using System.Collections;
using UnityEngine.UI;   // Text 사용

public class Timer : MonoBehaviour {
    // 열리고 닫히는 시간 -----------
    public float openTime;
    public float closeTime;
    // ------------------------------

    public GameObject endPoint;     // 개방 될 문임

    // 그래픽으로 시간의 흐름을 보여줌 -----------------------------------
    public Scrollbar openTimer;     // 오픈 타이머
    public Scrollbar currentTimer;  // 현재 시간 타이머

    public Text openTimeText;    // 개방시간을 출력해줄 gui text
    public Text currentTimeText; // 시간을 출력해줄 gui text
    public Text timeCycleText;   // 몇 번 초과 됐는지 출력
    // -------------------------------------------------------------------

    float currentTime;           // 현재 시간
    int timeCycle;               // 시간 초과된 횟수
    
	void  Awake()
    {
        openTimeText.text = "개방 시간 : " + openTime + " ~ " + closeTime;
        openTimer.size = 1 - (openTime / closeTime);  // 시간 비율로 사이즈 잡아줌.

        Init();
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
            Init();
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
        }
        else
        {
            endPoint.SetActive(false);

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
    void Init()
    {
        currentTime = 0;
        currentTimeText.text = "현재 시간 : 0";
        currentTimer.value = 0;

        timeCycle = 0;
        timeCycleText.text = "초과된 횟수 : 0";

        endPoint.SetActive(true);
    }
}
