using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

    public GameObject obj;

    // 메인 카메라를 받아옴
    private Camera mainCam = null;
    

    // Start 함수 앞에서 호출됨.
    void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0) && ( obj.name == GetClickedObject().name ))
        {
            // 등록된 오브젝트와 같은 것을 눌렀다면 오브젝트의 클론을 생성
            Instantiate(obj).GetComponent<ObjectController>().HoldObject();

            // 오브젝트를 뽑았다면 UI를 제자리로 돌려둔다.
            GetComponent<ObjectUIManager>().SwitchPop();
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
}
