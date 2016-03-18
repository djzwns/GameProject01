using UnityEngine;
using System.Collections;

public class ObjectUIManager : MonoBehaviour {

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
        // 마우스가 눌렸다가 때질 때 실행
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 위치의 오브젝트를 받아옴
            clickedObj = GetClickedObject();

            // 누르면 팝업 시킴.. 하.. 맘에 안든다. 
            // 담에 오브젝트 많아지면 어케할지 생각좀 해봐야겠따
            if (clickedObj.Equals(objBox) && !isPop)
            {
                isPop = true;
                clickedObj.transform.position = new Vector2(-5.8f, 0f);

            }
            else if (clickedObj.Equals(objBox) && isPop)
            {
                isPop = false;
                clickedObj.transform.position = new Vector2(-18.8f, 0f);
            }
        }
    }


    // 생성 2016.03.18
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
}
