﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller {

	// Use this for initialization
	void Awake () {
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		GameObject.Find ("JumpButton").SetActive (false);
	}
	public void move(float speed) {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//Debug.Log (move);
		transform.position += move * speed * Time.deltaTime;
	}
	// Update is called once per frame
	void Update () {
		move (5);
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump ();
		}
	}
}
