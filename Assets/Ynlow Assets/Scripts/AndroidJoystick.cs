using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidJoystick : MonoBehaviour {

	public Vector3 standardPosition;

	// Use this for initialization
	void Awake () {
		standardPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
