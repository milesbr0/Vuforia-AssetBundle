/*===============================================================================
Copyright (c) 2015-2017 PTC Inc. All Rights Reserved.
 
Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using System.Collections;

public class TapHandler : MonoBehaviour
{
    private Touch inittouch = new Touch();
    public Camera cam;
    [SerializeField] private float rotSpeed = 0.5f, dir = -1;
    private float rotX = 0f, rotY = 0;
    private Vector3 originRot;

    private void Start()
    {
        originRot = cam.transform.eulerAngles;
        rotX = originRot.x;
        rotY = originRot.y;
    }

    void Update()
    {
        // On Android, the Back button is mapped to the Esc key
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began) inittouch = touch;
                else if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = inittouch.position.x - touch.position.x;
                    float deltaY = inittouch.position.y - touch.position.y;
                    rotX -= deltaX * Time.deltaTime * rotSpeed * dir;
                    rotY -= deltaY * Time.deltaTime * rotSpeed * dir;
                    rotX =Mathf.Clamp(rotX, -80f, 80f);
                    cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);          
                }
                else if (touch.phase == TouchPhase.Ended) inittouch = new Touch();
            }
		}

    }

    public void BackButton()
    {
       	Application.Quit();
    }


}
