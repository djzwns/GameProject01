using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour {
    Vector2 direction;  // 날려보낼 방향을 정함

    float fanPower = 1f;
    public float power = 10f;
    public GameObject windPoint;

    void Awake ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 줄기가 따로 움직이지 않게.
        //GameObject.Find("wind_").transform.position = transform.position + (new Vector3(-0.14f, -0.97f, 0f));
        transform.GetComponentInParent<Rigidbody2D>().transform.FindChild("wind_").transform.position = 
            transform.position + (new Vector3(-0.14f, -0.97f, 0f));


        // 내려둔 상태라면
        if (gameObject.GetComponentInParent<ObjectController>().IsDrop())
        {
            gameObject.GetComponentInParent<BoxCollider2D>().isTrigger = true;
            // 잠궈뒀던 포지션 개방!
            gameObject.GetComponentInParent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
    }

    // 바람 범위에 닿으면 바람의 방향으로 날려보냄
    // Enter가 아닌 Stay를 쓴 이유는 바람의 영향속에 있으면 계속 호출 되도록 하기 위해 사용
    void OnTriggerStay2D(Collider2D obj)
    {
        Debug.Log(gameObject.tag);
        if (gameObject.tag == "UserObject") fanPower = gameObject.GetComponentInParent<ObjectController>().GetPowerObject() * power;
        else fanPower = power;

        direction = windPoint.transform.position - transform.position;    // 바람의 방향을 저장해둠.
        if (obj.gameObject.tag == "Ball")
        {
            obj.GetComponent<Rigidbody2D>().AddForce( direction * fanPower, ForceMode2D.Force);
        }
    }
}
