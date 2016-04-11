using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour {
    Rigidbody2D rigid2d;
    ObjectController controller;

    public float leftRange;
    public float rightRange;
    public float power;

    public GameObject fixedWall;

	// Use this for initialization
	void Awake () {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.angularVelocity = power;
        controller = gameObject.GetComponent<ObjectController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag != "UserObject")
        {
            Push();
        }
        if (!controller.IsDrop())
        {
            fixedWall.transform.position = transform.position;
            // 내려놓기 전까지 움직임 없게 포지션, 회전 고정시킴
            if (rigid2d.constraints != RigidbodyConstraints2D.FreezeAll)
                FrozenPosRot();
        }
        else
        {
            Push();
            // 내려뒀으니깐 회전, 포지션 풀어줌
            if (rigid2d.constraints == RigidbodyConstraints2D.FreezeAll)
                MeltPosRot();
        }
    }

    // 포지션, 회전 막음
    void FrozenPosRot()
    {
        rigid2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // 포지션, 회전 풀어줌
    void MeltPosRot()
    {
        rigid2d.constraints = ~RigidbodyConstraints2D.FreezeAll;
    }

    // 추를 밀어주는 함수..
    public void Push()
    {
        if (gameObject.tag == "UserObject")
            power = (gameObject.GetComponentInParent<ObjectController>().GetPowerObject()) * 100f;

        //Debug.Log(body2d.angularVelocity);
        // 오른쪽으로 밀어줌.
        if (transform.rotation.z > 0
            && transform.rotation.z < rightRange
            && (rigid2d.angularVelocity > 0)
            && rigid2d.angularVelocity < power)
        {
            rigid2d.angularVelocity = power;
        }
        // 왼쪽으로 밀어줌
        else if (transform.rotation.z < 0
            && transform.rotation.z > leftRange
            && (rigid2d.angularVelocity < 0)
            && rigid2d.angularVelocity > power * -1)
        {
            rigid2d.angularVelocity = power * -1;
        }
    }
}
