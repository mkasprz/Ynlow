using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject attackButton;
	public Controller controller;
	public FootCollider foots;
	public GameObject androidButton;
	public bool hidden;

	public void jump() {
		controller.jump ();
	}

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
		controller.foots = foots;

	}

	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name == "Light") {
			hidden = true;
		}
	}

	public void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.name == "Light") {
			hidden = false;
		}
	}
	
}
