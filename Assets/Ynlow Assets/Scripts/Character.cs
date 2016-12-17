using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject jumpButton;
	public Controller controller;
	public FootCollider foots;
	public bool hidden;

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
		controller.foots = foots;

	}

	// Update is called once per frame
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
