using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  // SceneManager 사용

public class BallController : MonoBehaviour {
    GameObject startPoint;  // 공의 시작 위치를 잡아줌

    void Awake () {
        Init();
    }

    void OnTriggerEnter2D(Collider2D end)
    {
        // 골인지점 도착하면 스테이지 이동~
        if (end.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("stage01");
        }
    }

    void Init()
    {
        startPoint = GameObject.Find("StartPoint");
        // 시작 지점의 좌표를 공에 넣어줌.
        gameObject.transform.position = startPoint.transform.position;

        // 그림 출력 중단.
        startPoint.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Reset()
    {
        // 시작 점 그림 다시 출력
        startPoint.GetComponent<SpriteRenderer>().enabled = true;
    }
}
