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

    void Start()
    {
       
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
		}

    }

    public void BackButton()
    {
       	Application.Quit();
    }


}
