using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
    GameObject ball = null;
    public float camPositionZ = -8f;
    Vector3 zPosition;
    

	// Use this for initialization
	void Awake () {
        ball = GameObject.Find("Ball");
        zPosition = new Vector3(0, 0, camPositionZ);
	}
	
	// Update is called once per frame
	void Update () {
        //Camera.main.transform.position = ball.transform.position + zPosition;
    }

    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    public GameObject GetClickedObject()
    {
        // 마우스가 누른 오브젝트를 저장
        GameObject obj = null;

        // 마우스 좌표를 받아온다.
        Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

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
