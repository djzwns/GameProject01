using UnityEngine;
using System.Collections;

public class Powall : MonoBehaviour {
    public float power; // 공의 속도를 결정하는 힘이다.
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Ball")
        {
            // transform.right => x축의 방향으로 힘을 준다.
            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * power, ForceMode2D.Force);
        }
    }
}
