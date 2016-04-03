using UnityEngine;
using System.Collections;

public class Pulley : MonoBehaviour {
    public float speed = 1f;

	// Use this for initialization
	void Awake ()
    {
        // 유저 오브젝트면 콜라이더 끄기, 다른 오브젝트에 겹치게 할 수 있다.
        if (gameObject.tag != "Preview")
            gameObject.GetComponent<Collider2D>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        // 계속 돌아가게 만듬
        if (gameObject.GetComponentInParent<ObjectController>().IsDrop())
        {
            RotPulley();
        }
	}

    // 물레방아? 도르래? 아무튼 회전시킨다.
    void RotPulley()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
