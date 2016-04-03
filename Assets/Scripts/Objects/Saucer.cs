using UnityEngine;
using System.Collections;

public class Saucer : MonoBehaviour {
    public GameObject point;

	// Update is called once per frame
	void Update () {
        transform.position = point.transform.position;
	}
}
