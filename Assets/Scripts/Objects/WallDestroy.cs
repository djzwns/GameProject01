using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour {
    public float destroyTime = 0.2f;
    //public float respawnTime = 3f;
    //float timer = 0f;
    //float respawnTimer = 0f;

    //public GameObject objSelf;
    //bool isActive = true;

    void Update()
    {
        //if (!isActive)
        //{
        //    respawnTimer += Time.deltaTime;
        //    if (respawnTimer > respawnTime)
        //    {
        //        gameObject.SetActive(true);
        //        isActive = true;
        //    }
        //}
        //if (isCrash)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > destroyTime)
        //    {
        //        gameObject.SetActive(false);
        //        timer = 0f;
        //        isActive = false;
        //    }
        //}
    }


    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            //timer += Time.deltaTime;
            //if (timer > destroyTime)
            //{
            //    gameObject.SetActive(false);
            //    timer = 0f;
            //    isActive = false;
            //}
            Destroy(gameObject, destroyTime);
        }
    }
}
