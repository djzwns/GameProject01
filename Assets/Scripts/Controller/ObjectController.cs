using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour {
    bool isDrop;
    bool clickedObject;
    bool dropPossible;

    GameObject clickObj;

    public float rot = 0.5f;
    public GameObject userObject;
    public Canvas rotationCanvas;

    void Awake()
    {
        //rotationCanvas = gameObject.GetComponentInChildren<Canvas>();
        dropPossible = true;
        clickedObject = false;
        rotationCanvas.enabled = false;
    }
    
    // 업뎃
    void Update()
    {
        if (!isDrop && gameObject.tag == "UserObject") { MoveObject(); }
        if (clickedObject) { RotationObject(); }

        if (Input.GetMouseButtonUp(0) && (gameObject.name.Contains(GetClickedObject().name)))
        {
            clickObj = GetClickedObject();
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

    // 다른 오브젝트와 겹치면 드롭 불가.
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
        float sliderVal = (rotationCanvas.GetComponentInChildren<Slider>().value - rot) / rot;
        // 슬라이더 값만큼 z축을 회전시킴 최대 90도
        userObject.transform.rotation = Quaternion.AngleAxis (sliderVal * 180f, new Vector3( 0, 0, 1f));
    }

    // 오브젝트 클릭 on/ off 관련 --------------------------------------------
    void ObjectClickOn()
    {
        clickedObject = true;
        rotationCanvas.enabled = true;
    }

    //void ObjectClick(GameObject obj)
    //{
    //    clickedObject = !clickedObject;
    //    obj.GetComponentInChildren<Canvas>().enabled = !(obj.GetComponent<Canvas>().enabled);
    //}

    void ObjectClickOff()
    {
        clickedObject = false;
        rotationCanvas.enabled = false;
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
