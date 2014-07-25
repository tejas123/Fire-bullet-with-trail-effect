using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    private Vector3 initialVelocity;
    private int collisionCounter = 0;
    private bool printed = false;



    void Start()
    {
    }

    void Update()
    {
        transform.right = rigidbody.velocity.normalized;
        if (!printed && gameObject.rigidbody.velocity != new Vector3(0, 0, 0))
        {
            initialVelocity = gameObject.rigidbody.velocity;
            printed = true;
        }
    }

    public Vector3 getInitialVelocity()
    {
        return initialVelocity;
    }



    void OnCollisionExit(Collision collisionInfo)
    {
        // if (collisionInfo.transform.CompareTag("Wall"))
        //   {
        //       collisionCounter++;
        //   }
        //   if (collisionCounter >= 10)
        Destroy(gameObject);
    }


}