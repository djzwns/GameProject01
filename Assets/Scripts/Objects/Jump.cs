using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float power = 1;

    void Awake()
    {
        gameObject.GetComponent<EdgeCollider2D>().sharedMaterial.bounciness = power;
    }
	// Update is called once per frame
	void Update () {
        // 내려둔 상태라면
        if (gameObject.GetComponentInParent<ObjectController>().IsDrop())
        {
            gameObject.GetComponent<EdgeCollider2D>().isTrigger = false;
            gameObject.GetComponents<BoxCollider2D>()[1].isTrigger = false;
            // 잠궈뒀던 포지션 개방!
           gameObject.GetComponentInParent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
	}
}
