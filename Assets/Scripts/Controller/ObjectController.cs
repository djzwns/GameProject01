using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour {
    bool isDrop;
    bool clickedObject;
    bool dropPossible;

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

        if (Input.GetMouseButtonUp(0) && (GetClickedObject().name + "(Clone)") == gameObject.name)
        {
            if(!clickedObject)
                ObjectClickOn();
            else
                ObjectClickOff();
        }

        if (Input.GetMouseButtonUp(0) && (GetClickedObject().name + "(Clone)") != gameObject.name)
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
        // 슬라이더 값만큼 z축을 회전시킴 최대 180도
        userObject.transform.rotation = Quaternion.AngleAxis (
            (rotationCanvas.GetComponentInChildren<Slider>().value / 0.5f) * -180f, 
            new Vector3( 0, 0, 1f)
        );
    }

    // 오브젝트 클릭 on/ off
    void ObjectClickOn()
    {
        clickedObject = true;
        rotationCanvas.enabled = true;
    }

    void ObjectClickOff()
    {
        clickedObject = false;
        rotationCanvas.enabled = false;
    }

    GameObject GetClickedObject()
    {
        return GameObject.Find("GameManager").GetComponent<CameraManager>().GetClickedObject();
    }

    // 오브젝트를 잡는다.
    public void HoldObject()
    {
        isDrop = false;
    }
}
