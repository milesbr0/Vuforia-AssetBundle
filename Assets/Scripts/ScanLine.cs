using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ScanLine : MonoBehaviour {

    public GameObject scanImage;
    private bool isGoingUp = true;
    private Camera cam;


    private bool isEnabled = true;

    // Use this for initialization
    void Start() {
        // Camera should named to MainCamera
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (isEnabled)
        {
            int step = cam.pixelHeight / 200;
            if (isGoingUp)
            {
                up(step);
                if (scanImage.transform.position.y >= cam.pixelHeight - 1)
                {
                    isGoingUp = false;
                }
            }
            else
            {
                down(step);
                if (scanImage.transform.position.y <= 1)
                {
                    isGoingUp = true;
                }
            }
        }
    }

    private void up(int step)
    {
        Vector3 position = scanImage.transform.position;
        position.y += step;
        scanImage.transform.position = position;
    }

    private void down(int step)
    {
        Vector3 position = scanImage.transform.position;
        position.y -= step;
        scanImage.transform.position = position;
    }

    public void enable()
    {
        isEnabled = true;
        scanImage.SetActive(true);
    }

    public void disable()
    {
        isEnabled = false;
        scanImage.SetActive(false);
    }
}
