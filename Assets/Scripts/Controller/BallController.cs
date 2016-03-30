using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    GameObject startPoint;
    GameObject endPoint;

    void Awake () {
        Init();
    }

    public void Reset()
    {
        startPoint.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Init()
    {
        startPoint = GameObject.Find("StartPoint");
        endPoint = GameObject.Find("EndPoint");
        // 시작 지점의 좌표를 공에 넣어줌.
        gameObject.transform.position = startPoint.transform.position;

        startPoint.GetComponent<SpriteRenderer>().enabled = false;
    }
}
