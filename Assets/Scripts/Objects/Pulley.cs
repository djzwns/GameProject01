using UnityEngine;
using System.Collections;

public class Pulley : MonoBehaviour {
    float speed;                // 실제로 돌려주는 속도
    public float power = 50f;    // 돌아가는 힘, 즉 회전 속도
    

    // Use this for initialization
    void Awake()
    {
        // 유저 오브젝트면 콜라이더 끄기, 다른 오브젝트에 겹치게 할 수 있다.
        if (gameObject.tag != "Preview")
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        speed = gameObject.GetComponentInParent<ObjectController>().GetPowerObject() * power;
        // 계속 돌아가게 만듬
        //if (gameObject.GetComponentInParent<ObjectController>().IsDrop() && speed != 0)
        //{
        //}
        if (gameObject.tag != "Preview")
        {
            RotPulley();
        }
    }

    // 물레방아? 도르래? 아무튼 회전시킨다.
    void RotPulley()
    {
        // Vector3.forward : z축으로 회전 시킴
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
