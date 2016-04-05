using UnityEngine;
using System.Collections;

public class Saucer : MonoBehaviour {
    public GameObject point;

	// Update is called once per frame
	void Update () {
        // point 좌표로 따라붙게 만들음.
        transform.position = point.transform.position;
	}
}
