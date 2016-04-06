using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    float power = 1f;

    void Awake()
    {
        //gameObject.GetComponent<EdgeCollider2D>().sharedMaterial.bounciness = power;
    }
    // Update is called once per frame
    void Update()
    {

        // 내려둔 상태라면
        if (gameObject.GetComponentInParent<ObjectController>().IsDrop())
        {
            gameObject.GetComponent<EdgeCollider2D>().isTrigger = false;
            gameObject.GetComponents<BoxCollider2D>()[1].isTrigger = false;
            // 잠궈뒀던 포지션 개방!
            gameObject.GetComponentInParent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Ball")
        {
            power = (gameObject.GetComponentInParent<ObjectController>().GetPowerObject()) * 10f;
            //gameObject.GetComponent<EdgeCollider2D>().sharedMaterial.bounciness = power;
            //Debug.Log(power);
            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power, ForceMode2D.Impulse);
        }
    }
}
