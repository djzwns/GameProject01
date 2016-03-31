using UnityEngine;
using System.Collections;
using UnityEngine.UI;   // Text 사용

public class Timer : MonoBehaviour {
    // 열리고 닫히는 시간 -----------
    public float openTime;
    public float closeTime;
    // ------------------------------

    public GameObject endPoint;  // 개방 될 문임

    public Text openTimeText;    // 개방시간을 출력해줄 gui text
    public Text currentTimeText; // 시간을 출력해줄 gui text

    float currentTime;           // 현재 시간
    
	void  Awake()
    {
        openTimeText.text = "개방 시간 : " + openTime + " ~ " + closeTime;
        endPoint.SetActive(false);
        Init();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 게임에 공이 생기면 카운트 시작.
        if (GameObject.Find("Ball(Clone)") != null)
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
        currentTime += Time.deltaTime;
        currentTimeText.text = "현재 시간 : " + currentTime;

        // 열리는 시간 ~ 닫히는 시간 사이에 있으면 종료점 활성화
        if (openTime <= currentTime && currentTime <= closeTime)
        {
            endPoint.SetActive(true);
        }
        else
        {
            endPoint.SetActive(false);
        }
    }

    void Init()
    {
        currentTime = 0;
        currentTimeText.text = "현재 시간 : 0";
    }
}
