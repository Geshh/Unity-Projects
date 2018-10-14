using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetect;

    private float timeBtwRotation = 1f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (timeBtwRotation > 0)
            {
                speed = 0;
                timeBtwRotation -= Time.deltaTime;
            }
            else
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
                timeBtwRotation = 1f;
                speed = 1f;
            }
        }
    }
}
