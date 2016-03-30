using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    public GameObject startPoint;
    public GameObject endPoint;

    void Awake () {
        InitBall();
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
        gameObject.transform.position = startPoint.transform.position;
        //gameObject.GetComponent<Rigidbody2D>().Sleep();
        //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        //gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
}
