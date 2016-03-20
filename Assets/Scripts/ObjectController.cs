using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {
    bool isDrop;

    void Awake()
    {
        isDrop = true;
    }
    
    void Update() {

        if (!isDrop)
        {
            // 내려 두기 전까지 계속 마우스 따라 이동
            gameObject.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(9.0f);
            if (Input.GetMouseButton(0))
                isDrop = true;

        }
    }
    
    // 오브젝트를 잡는다.
    public void HoldObject()
    {
        isDrop = false;
    }
}
