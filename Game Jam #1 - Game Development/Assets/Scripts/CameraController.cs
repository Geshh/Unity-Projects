using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    private bool isZoomedOut = false;

    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.M) && isZoomedOut == false)
            {
                cameras[0].gameObject.SetActive(false);
                cameras[1].gameObject.SetActive(true);
                isZoomedOut = true;
            }
            else if (isZoomedOut == true)
            {
                cameras[0].gameObject.SetActive(true);
                cameras[1].gameObject.SetActive(false);
                isZoomedOut = false;
            }
        }
    }
}
