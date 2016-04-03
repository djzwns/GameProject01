﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour {
    bool isDrop;                // 내려놨는지 아닌지 상태를 나타냄.
    bool clickedObject;         // 눌려있는지 아닌지, 게이지 바를 띄워준다.
    bool dropPossible;          // 내려두려는 위치에 내려둘수있는지 체크

    // GetComponents 사용시 0은 회전, 1은 파워 조절 -----------------------------
    // ex) GetComponentsInChildren<Slider>()[POWER].value 
    // 파워인덱스는 1을 뜻하며 동일 컴퍼넌트에서 두번째 컴퍼넌트를 사용한다는 의미
    const int ROTATION = 0;
    const int POWER = 1;
    // --------------------------------------------------------------------------
    

    float value = 0.5f;         // 슬라이더의 값이 0~1인데 이것을 -0.5~0.5 사이에서 쓰기위해 뺴주는 값
    public GameObject userObject;
    public Canvas statCanvas;   // 회전, 파워 관리하는 캔버스

    void Awake()
    {
        //rotationCanvas = gameObject.GetComponentInChildren<Canvas>();
        dropPossible = true;
        clickedObject = false;
        statCanvas.enabled = false;
    }
    
    // 업뎃
    void Update()
    {
        if (!isDrop && gameObject.tag == "UserObject") { MoveObject(); }
        if (clickedObject) { RotationObject(); }

        if (Input.GetMouseButtonUp(0) && (gameObject.name.Contains(GetClickedObject().name)))
        {
            if (!clickedObject)
                ObjectClickOn();
            else
                ObjectClickOff();
        }

        if (Input.GetMouseButtonUp(0) && !(gameObject.name.Contains(GetClickedObject().name)))
        {
            ObjectClickOff();
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
        gameObject.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(10.0f);
        if (Input.GetMouseButton(0) && dropPossible)
        {
            isDrop = true;
        }
    }

    // 오브젝트 회전
    void RotationObject()
    {
        float sliderVal = (statCanvas.GetComponentsInChildren<Slider>()[ROTATION].value - value);
        // 슬라이더 값만큼 z축을 회전시킴 최대 90도
        userObject.transform.rotation = Quaternion.AngleAxis (sliderVal * 180f, new Vector3( 0, 0, 1f));
    }

    // 파워 값을 반환해준다. 범위 ( -0.5 ~ 0.5 )
    public float GetPowerObject() 
    {
        return statCanvas.GetComponentsInChildren<Slider>()[POWER].value - value;
    }

    // 오브젝트 클릭 on/ off 관련 --------------------------------------------
    void ObjectClickOn()
    {
        clickedObject = true;
        statCanvas.enabled = true;
    }

    //void ObjectClick(GameObject obj)
    //{
    //    clickedObject = !clickedObject;
    //    obj.GetComponentInChildren<Canvas>().enabled = !(obj.GetComponent<Canvas>().enabled);
    //}

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
}
