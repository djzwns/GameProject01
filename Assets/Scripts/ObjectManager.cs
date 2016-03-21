using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
    private GameObject clickObj;

    // 메인 카메라를 받아옴
    private Camera mainCam = null;
    

    // Start 함수 앞에서 호출됨.
    void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            clickObj = GetClickedObject();

            if (clickObj.tag == "Preview")
            {
                // 오브젝트의 클론을 생성
                CreateObject().GetComponent<ObjectController>().HoldObject();

                // 오브젝트를 뽑았다면 UI를 제자리로 돌려둔다.
                GetComponent<ObjectUIManager>().SwitchPop();
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
        if (hit.collider != null)
        {
            obj = hit.collider.gameObject;
        }

        return obj;
    }

    // 오브젝트 생성 후 생성된 오브젝트 반환
    GameObject CreateObject()
    {
        GameObject obj = Instantiate(clickObj);

        // 태그와 트리거를 바꿔준다.
        obj.gameObject.tag = "UserObject";
        obj.GetComponent<Collider2D>().isTrigger = false;

        return obj;
    }
    public void DestroyAllObject()
    {
        GameObject destroyObj = GameObject.FindGameObjectWithTag("UserObject");

        // 오브젝트가 null이 될때 까지 찾아서 다 디스트로이 시킴.
        while (destroyObj != null)
        {
            // Destroy 를 쓰려 했는데 바로 지워지지 않고 
            // 남았다가 Update 종료 시점에서 지워지는 탓에 유니티 먹통 ㅠ
            DestroyImmediate(destroyObj); 
            destroyObj = GameObject.FindGameObjectWithTag("UserObject");
        }
    }
}
