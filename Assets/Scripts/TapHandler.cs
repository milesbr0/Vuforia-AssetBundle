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
    public GameObject model;
    [SerializeField] private float rotSpeed = 0.5f;
    private float rotX = 0f;
    private Vector3 originRot;

    private void Start(){
        originRot = model.transform.eulerAngles;
        rotX = originRot.x;
    }

    void Update(){
        // On Android, the Back button is mapped to the Esc key
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape)) Application.Quit();

            foreach (Touch touch in Input.touches){

                if (touch.phase == TouchPhase.Began) inittouch = touch;

                else if (touch.phase == TouchPhase.Moved){
                    float deltaX = inittouch.position.x - touch.position.x;
                    rotX -= deltaX * rotSpeed;
                    Vector3 RotateAxis = Vector3.forward;
                    model.transform.rotation = Quaternion.AngleAxis(rotX, RotateAxis);
                }
                else if (touch.phase == TouchPhase.Ended) inittouch = new Touch();
            }
		}

    }

    public void BackButton()
    {
        Debug.Log("I've been pressed!");
       	Application.Quit();
    }


}
