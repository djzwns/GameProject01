using UnityEngine;
using System.Collections;

public class Powall : MonoBehaviour {
    float power; // 공의 속도를 결정하는 힘이다.
    public float _power;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionStay2D(Collision2D obj)
    {
        // 슬라이더에 따른 방향, 힘 등이 변함
        if (gameObject.tag == "UserObject") power = (gameObject.GetComponentInParent<ObjectController>().GetPowerObject() - 0.5f) * 2f * _power;
        else power = _power;

        if (obj.gameObject.tag == "Ball")
        {
            // transform.right => x축의 방향으로 힘을 준다.
            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * power, ForceMode2D.Force);
        }
    }
}
