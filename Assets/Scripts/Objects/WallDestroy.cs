using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour {

    public float destroyTime = 0.2f;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Destroy(gameObject, destroyTime);
        }
    }
}
