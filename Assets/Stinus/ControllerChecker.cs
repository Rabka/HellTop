using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("P1A"))
            Debug.Log("P 1 A");
	    if (Math.Abs(Input.GetAxis("P1Horizontal")) > 0.1)
	        Debug.Log("P 1: " + Input.GetAxis("P1Horizontal"));
	    if (Input.GetButton("P2A"))
	        Debug.Log("P 2 A");
	    if (Math.Abs(Input.GetAxis("P2Horizontal")) > 0.1)
	        Debug.Log("P 2: " + Input.GetAxis("P2Horizontal"));
	    if (Input.GetButton("P3A"))
	        Debug.Log("P 3 A");
	    if (Math.Abs(Input.GetAxis("P3Horizontal")) > 0.1)
	        Debug.Log("P 3: " + Input.GetAxis("P3Horizontal"));
	    if (Input.GetButton("P4A"))
	        Debug.Log("P 4 A");
	    if (Math.Abs(Input.GetAxis("P4Horizontal")) > 0.1)
	        Debug.Log("P 4: " + Input.GetAxis("P4Horizontal"));
    }
}
