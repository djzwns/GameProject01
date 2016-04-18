using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  // SceneManager 사용

public class BallController : MonoBehaviour {
    GameObject startPoint;          // 공의 시작 위치를 잡아줌
    StageManager stageManager;

    //public GameObject light;
    
    //int ballCount = 0;

    void Awake () {
        gameObject.SetActive(false);
        stageManager = GameObject.Find("GameManager").GetComponent<StageManager>();
        Init();
    }

    void Update()
    {
        //light.transform.position = transform.position;
    }

    void OnTriggerEnter2D(Collider2D end)
    {
        // 골인지점 도착하면 스테이지 이동~
        if (end.tag == "Finish")
        {
            GameReset();
            stageManager.StageClear();
            stageManager.NextStage();
        }
    }

    void Init()
    {
        startPoint = GameObject.Find("StartPoint");

        if (startPoint != null)
        {
            // 시작 지점의 좌표를 공에 넣어줌.
            gameObject.transform.position = startPoint.transform.position;

            // 그림 출력 중단.
            startPoint.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
            gameObject.transform.position = new Vector3( 0f, 0f, 0f );
    }

    void Reset()
    {
        if (startPoint != null)
        {
            // 시작 점 그림 다시 출력
            startPoint.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // 시작
    public void GamePlay()
    {
        //if (ballCount == 0)
        //{
        //    ++ballCount;
        //}
        startPoint = GameObject.Find("StartPoint");
        gameObject.transform.position = startPoint.transform.position;
        gameObject.SetActive(true);
    }

    // 리셋
    public void GameReset()
    {
        // 공이 1개 일때 파괴 후 카운트 감소
        //if (ballCount == 1)
        //{
            Reset();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        //    --ballCount;
        //}
    }
}
