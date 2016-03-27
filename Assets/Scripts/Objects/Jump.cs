using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        // 내려둔 상태라면
        if (gameObject.GetComponentInParent<ObjectController>().IsDrop())
        {
            // 잠궈뒀던 포지션 개방!
           gameObject.GetComponentInParent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
	}
}
