using UnityEngine;
using System.Collections;

public class PlatFormScript : MonoBehaviour
{

    private Vector3 savedVelocity, initialVelocity, tempVelocity, newtempVelocity;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.transform.CompareTag("Bullet"))
        {
            initialVelocity = collisionInfo.transform.gameObject.GetComponent<BulletScript>().getInitialVelocity();
            savedVelocity = collisionInfo.gameObject.rigidbody.velocity;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.transform.CompareTag("Bullet"))
        {
            tempVelocity = collisionInfo.gameObject.rigidbody.velocity;
            if ((tempVelocity.x < 0 && initialVelocity.x < 0) || (tempVelocity.x > 0 && initialVelocity.x > 0))
                newtempVelocity.x = initialVelocity.x;
            else
                newtempVelocity.x = initialVelocity.x * -1;

            if ((tempVelocity.y < 0 && initialVelocity.y < 0) || (tempVelocity.y > 0 && initialVelocity.y > 0))
                newtempVelocity.y = initialVelocity.y;
            else
                newtempVelocity.y = initialVelocity.y * -1;

            collisionInfo.gameObject.rigidbody.velocity = newtempVelocity;

        }
    }
}
