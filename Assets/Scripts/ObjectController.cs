using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {
    bool isDrop;
    bool dropPossible;

    void Awake()
    {
        //isDrop = true;
        dropPossible = true;
    }
    
    void Update() {

        if (!isDrop && gameObject.name != "Wall" )
        {
            // 내려 두기 전까지 계속 마우스 따라 이동
            gameObject.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(9.0f);
            if (Input.GetMouseButton(0) && dropPossible)
                isDrop = true;

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

    // 오브젝트를 잡는다.
    public void HoldObject()
    {
        isDrop = false;
    }
}
