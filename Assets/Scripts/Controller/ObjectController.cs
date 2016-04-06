using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour {
    bool isDrop;                // 내려놨는지 아닌지 상태를 나타냄.
    bool clickedObject;         // 눌려있는지 아닌지, 게이지 바를 띄워준다.
    bool dropPossible;          // 내려두려는 위치에 내려둘수있는지 체크
    GameObject clickedObj;      // 눌린 오브젝트 확인용

    // GetComponents 사용시 0은 회전, 1은 파워 조절 -----------------------------
    // ex) GetComponentsInChildren<Slider>()[POWER].value 
    // 파워인덱스는 1을 뜻하며 동일 컴퍼넌트에서 두번째 컴퍼넌트를 사용한다는 의미
    const int ROTATION = 0;
    const int POWER = 1;
    // --------------------------------------------------------------------------
    
        
    public GameObject userObject;   // 유저오브젝트 회전 등을 관리하기 위한 변수
    public Canvas statCanvas;       // 회전, 파워 관리하는 캔버스

    void Awake()
    {
        dropPossible = true;
        clickedObject = false;
        statCanvas.enabled = false;
    }
    
    // 업뎃
    void Update()
    {
        if (!isDrop && gameObject.tag == "UserObject") { MoveObject(); }
        if (clickedObject && gameObject.tag == "UserObject") { RotationObject(); }


        // 눌렸을 때 설정바 온오프
        if (Input.GetMouseButtonUp(0))
        {
            clickedObj = GetClickedObject();
            Debug.Log(clickedObj);
            if (clickedObj.tag == "UserObject" && gameObject.name == clickedObj.name)
            {
                ObjectClick();
            }
            else
            {
                ObjectClickOff();
            }
        }
    }

    // 다른 오브젝트와 충돌 여부 체크 -------------------------
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "UserObject")
        {
            dropPossible = false;
        }
    }
    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "UserObject")
        {
            dropPossible = true;
        }
            
    }
    // ---------------------------------------------------------

    // 오브젝트를 움직인다.
    void MoveObject()
    {
        // 내려 두기 전까지 계속 마우스 따라 이동
        transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(10.0f);
        statCanvas.transform.position = transform.position;
        if (Input.GetMouseButtonDown(0) && dropPossible)
        {
            isDrop = true;
        }
    }

    // 오브젝트 회전
    void RotationObject()
    {
        // value 에 0.5를 뺀 이유는 value 값을 -0.5~0.5로 쓰기 위해서임
        float sliderVal = (statCanvas.GetComponentsInChildren<Slider>()[ROTATION].value - 0.5f);
        // 슬라이더 값만큼 z축을 회전시킴 최대 90도
        transform.rotation = Quaternion.AngleAxis (sliderVal * 180f, new Vector3( 0, 0, 1f));
    }

    // 파워 값을 반환해준다.
    public float GetPowerObject() 
    {
        return statCanvas.GetComponentsInChildren<Slider>()[POWER].value;
    }

    // 오브젝트 클릭 on/ off 관련 --------------------------------------------
    void ObjectClick()
    {
        clickedObject = !clickedObject;
        statCanvas.enabled = !statCanvas.enabled;
    }

    void ObjectClickOff()
    {
        clickedObject = false;
        statCanvas.enabled = false;
    }
    // -----------------------------------------------------------------------

    GameObject GetClickedObject()
    {
        return GameObject.Find("GameManager").GetComponent<CameraManager>().GetClickedObject();
    }

    // 오브젝트를 잡는다.
    public void HoldObject()
    {
        isDrop = false;
    }

    public bool IsDrop()
    {
        return isDrop;
    }
    public bool IsClicked()
    {
        return clickedObject;
    }
}
