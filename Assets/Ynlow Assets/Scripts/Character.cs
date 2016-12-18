using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private Rigidbody2D rigid;
	public GameObject attackButton;
	public Controller controller;
	public FootCollider foots;
	public GameObject androidButton;
	public bool hidden;
	bool right = true;

	public void jump() {
		controller.jump ();
	}

	void Awake () {
		rigid = GetComponent<Rigidbody2D> ();
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
		if (rigid.velocity.x < 0 && right)
			flip ();
		else if (rigid.velocity.x >= 0 && !right)
			flip ();
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

	private void flip()
	{
		right = !right;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
