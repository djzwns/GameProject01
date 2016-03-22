using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    Vector3 startPosition;
    
	void Awake () {
        startPosition = gameObject.transform.position;
        //gameObject.GetComponent<Rigidbody2D>().Sleep();
    }

    public void MoveBall()
    {
        //gameObject.GetComponent<Rigidbody2D>().WakeUp();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }

    public void InitBall()
    {
        gameObject.transform.position = startPosition;
        gameObject.GetComponent<Rigidbody2D>().Sleep();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
}
