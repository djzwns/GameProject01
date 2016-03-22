using UnityEngine;
using System.Collections;

public class ObjectUIManager : MonoBehaviour {
    public GameObject ball;
    public GameObject objBox;

    // 메인 카메라를 받아옴
    private Camera mainCam = null;
    // object UI의 상태
    private bool isPop = false;
    // 마우스에 눌린 오브젝트
    private GameObject clickedObj;


    void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        // 마우스가 눌렸다가 때질 때 실행. 괄호의 0은 왼쪽 클릭을 의미
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 위치의 오브젝트를 받아옴
            clickedObj = GetClickedObject();

            // 누르면 팝업 시킴.
            if (clickedObj.Equals(objBox))
            {
                SwitchPop();
            }
            if (clickedObj.name == "play")
            {
                ball.GetComponent<BallController>().MoveBall();
            }
            if (clickedObj.name == "reset")
            {
                ball.GetComponent<BallController>().InitBall();
                GetComponent<ObjectManager>().DestroyAllObject();
            }
        }
    }


    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    private GameObject GetClickedObject()
    {
        // 마우스가 누른 오브젝트를 저장
        GameObject obj = null;

        // 마우스 좌표를 받아온다.
        Ray clickRay = mainCam.ScreenPointToRay(Input.mousePosition);

        // raycast를 이용해 마우스 클릭한 위치를 찾는다.
        RaycastHit2D hit = Physics2D.GetRayIntersection(clickRay, 10f);

        // 클릭한 오브젝트가 존재하면 obj에 클릭된 오브젝트를 입력해준다.
        if ( hit.collider != null )
        {
            obj = hit.collider.gameObject;
        }
        
        return obj;
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
