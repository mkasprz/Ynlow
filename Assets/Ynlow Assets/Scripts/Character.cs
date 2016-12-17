using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private Controller controller;

	// Use this for initialization
	void Awake () {
		
		foreach (string a in Input.GetJoystickNames()) {
			Debug.Log (a);
		}
		controller = new KeyboardController ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
