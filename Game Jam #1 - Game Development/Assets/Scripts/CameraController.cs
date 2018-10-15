using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator anim;
    private bool isZoomedOut = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.M) && isZoomedOut == false)
            {
                Debug.Log("Clicked" + isZoomedOut);
                anim.SetTrigger("Active");
                isZoomedOut = true;
            }
            else if (isZoomedOut == true)
            {
                Debug.Log("Clicked" + isZoomedOut);
                anim.SetTrigger("Deactivate");
                isZoomedOut = false;
            }
        }
    }
}
