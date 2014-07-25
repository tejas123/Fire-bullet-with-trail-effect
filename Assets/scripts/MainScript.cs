using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
    public GameObject bullet, gunmanHand, bulletPosition,  shotIcon;


    private int speedOfBullet = 2500;

    private bool moving = false;
    private Vector3 initialPosition, movePosition;
    private float angleInDegrees = 0;

 



    private GameObject scene;
    void Start()
    {
        loadInitialData();
    }

    public void loadInitialData()
    {
        gunmanHand.transform.eulerAngles = new Vector3(0, 0, 0);
        shotIcon.renderer.enabled = false;

      
    }

    void Update()
    {
        checkForTouchActions();
    }

    private void checkForTouchActions()
    {
        if (Input.GetMouseButtonDown(0))
        {

            moving = true;
            shotIcon.renderer.enabled = true;
            initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            double angle2 = Mathf.Atan2(initialPosition.y - gunmanHand.transform.position.y,
            initialPosition.x - gunmanHand.transform.position.x);

            angleInDegrees = (float)(angle2);
            angleInDegrees = Mathf.Rad2Deg * angleInDegrees;

            gunmanHand.transform.eulerAngles = new Vector3(0, 0, angleInDegrees);

        }
        if (moving)
        {
            if (gunmanHand)
            {
                movePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                shotIcon.transform.position = new Vector3(movePosition.x, movePosition.y, -5);
                double angle1 = Mathf.Atan2(gunmanHand.transform.position.y - initialPosition.y,
                gunmanHand.transform.position.x - initialPosition.x);
                double angle2 = Mathf.Atan2(gunmanHand.transform.position.y - movePosition.y,
                gunmanHand.transform.position.x - movePosition.x);

                angleInDegrees = (float)(angle2 - angle1);
                angleInDegrees = Mathf.Rad2Deg * angleInDegrees;

                gunmanHand.transform.eulerAngles += new Vector3(0, 0, angleInDegrees);

                initialPosition = movePosition;

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            shotIcon.renderer.enabled = false;
            if (moving == true)
            {
                Vector3 pos = bulletPosition.transform.position;
                pos.z = -1;
                fireBullet(pos);
            }
            moving = false;
        }
    }
    private void fireBullet(Vector3 pos)
    {

        GameObject currentBullet = (GameObject)Instantiate(bullet, pos, Quaternion.identity);
        Vector3 angle = gunmanHand.transform.eulerAngles;
        currentBullet.transform.eulerAngles = angle;

        Vector3 forceVector = currentBullet.transform.right;
        currentBullet.rigidbody.AddForce(forceVector * speedOfBullet * 1.5f, ForceMode.Impulse);
    }

}