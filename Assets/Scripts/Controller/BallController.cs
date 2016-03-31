using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {
    GameObject startPoint;

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

        startPoint.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Reset()
    {
        startPoint.GetComponent<SpriteRenderer>().enabled = true;
    }
}
