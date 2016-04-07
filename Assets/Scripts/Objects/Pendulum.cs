using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour {
    Rigidbody2D rigid2d;
    ObjectController controller;

    public float leftRange;
    public float rightRange;
    public float velocityThreshold;

	// Use this for initialization
	void Awake () {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.angularVelocity = velocityThreshold;
        controller = gameObject.GetComponent<ObjectController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (controller.IsDrop())
        {
            //MeltPosRot();
            Push();
        }
        if (controller.IsClicked())
        {
            //FrozenPosRot();
        }

    }

    //// 포지션, 회전 막음
    //void FrozenPosRot()
    //{
    //    rigid2d.constraints = RigidbodyConstraints2D.FreezeAll;
    //}

    //// 포지션, 회전 풀어줌
    //void MeltPosRot()
    //{
    //    rigid2d.constraints = ~RigidbodyConstraints2D.FreezeAll;
    //}

    // 추를 밀어주는 함수..
    public void Push()
    {
        //Debug.Log(body2d.angularVelocity);
        // 오른쪽으로 밀어줌.
        if (transform.rotation.z > 0
            && transform.rotation.z < rightRange
            && (rigid2d.angularVelocity > 0)
            && rigid2d.angularVelocity < velocityThreshold)
        {
            rigid2d.angularVelocity = velocityThreshold;
        }
        // 왼쪽으로 밀어줌
        else if (transform.rotation.z < 0
            && transform.rotation.z > leftRange
            && (rigid2d.angularVelocity < 0)
            && rigid2d.angularVelocity > velocityThreshold * -1)
        {
            rigid2d.angularVelocity = velocityThreshold * -1;
        }
    }
}
