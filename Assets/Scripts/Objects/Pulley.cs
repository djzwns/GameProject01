using UnityEngine;
using System.Collections;

public class Pulley : MonoBehaviour {
    float speed;                // 실제로 돌려주는 속도
    public float power = 100f;    // 돌아가는 힘, 즉 회전 속도
    
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.tag == "UserObject")
            speed = (gameObject.GetComponentInParent<ObjectController>().GetPowerObject()-0.5f) * power;
        else
            speed = power;

        RotPulley();
    }

    // 물레방아? 도르래? 아무튼 회전시킨다.
    void RotPulley()
    {
        // Vector3.forward : z축으로 회전 시킴
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
