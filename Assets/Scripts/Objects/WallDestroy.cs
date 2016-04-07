using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour {

    public float destroyTime = 0.2f;
    //public float respawnTime = 3f;
    float timer = 0f;
    

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            timer += Time.deltaTime;
            if (timer > destroyTime) 
            {
                gameObject.SetActive(false);
                timer = 0f;
            }
            //Destroy(gameObject, destroyTime);
        }
    }
}
