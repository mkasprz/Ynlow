using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject attackButton;
	public Controller controller;
	public FootCollider foots;
	public GameObject androidButton;

	//private Controller controller;
	public void jump() {
		controller.jump ();
	}

	// Use this for initialization
	void Awake () {
		if (Application.platform == RuntimePlatform.Android) {
			controller = gameObject.AddComponent<AndroidController> ();
			((AndroidController)controller).a = androidButton.GetComponent<AndroidJoystick>();
			((AndroidController)controller).attackButton = attackButton;
		} else {
			controller = gameObject.AddComponent<KeyboardController> ();
			androidButton.SetActive (false);
			attackButton.SetActive (false);
		}
//		controller.jumpButton = jumpButton;
		controller.foots = foots;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
