using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    GameObject ball = null;
    public float camPositionZ = -8f;
    Vector3 zPosition;
    

	// Use this for initialization
	void Awake () {
        ball = GameObject.Find("Ball");
        zPosition = new Vector3(0, 0, camPositionZ);
	}
	
	// Update is called once per frame
	void Update () {
        //Camera.main.transform.position = ball.transform.position + zPosition;
    }
    
}
