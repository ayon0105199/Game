using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class testingAR : MonoBehaviour ,IVirtualButtonEventHandler {

    GameObject vbButtonObject;
	// Use this for initialization
	void Start () {
        vbButtonObject = GameObject.Find("VirtualButton");
        vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        throw new NotImplementedException();
        Debug.Log("Button Down!!");
    }

    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        throw new NotImplementedException();
    }
}
