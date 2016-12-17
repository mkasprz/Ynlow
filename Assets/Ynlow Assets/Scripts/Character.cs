using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject jumpButton;
	public Controller controller;

	//private Controller controller;
	public void jump() {
		controller.jump ();
	}

	// Use this for initialization
	void Awake () {
		if (Application.platform == RuntimePlatform.Android)
			controller = gameObject.AddComponent<AndroidController> ();
		else
			controller = gameObject.AddComponent<KeyboardController> ();
		controller.jumpButton = jumpButton;
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
