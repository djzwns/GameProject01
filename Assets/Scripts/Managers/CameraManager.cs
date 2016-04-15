using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
    void Start()
    {
        Screen.SetResolution(747, 420, false);
    }
    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    public GameObject GetClickedObject()
    {
        // 마우스가 누른 오브젝트를 저장
        GameObject obj = null;

        // 마우스 좌표를 받아온다.
        Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // raycast를 이용해 마우스 클릭한 위치를 찾는다.
        RaycastHit2D hit = Physics2D.GetRayIntersection(clickRay, 10f, -1);

        // 클릭한 오브젝트가 존재하면 obj에 클릭된 오브젝트를 입력해준다.
        if (hit.collider != null)
        {
            obj = hit.collider.gameObject;
        }

        return obj;
    }
}
