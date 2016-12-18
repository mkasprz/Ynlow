using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller {

	// Use this for initialization
	void Awake () {
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	public void move(float speed) {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		makeMove(move);
	}
	// Update is called once per frame
	void Update () {
		move (speed);
		if (Input.GetButtonDown("Jump")) {
			jump ();
		}
		cooldownCounter += Time.deltaTime;
		if (Input.GetButtonDown("Fire1") && cooldownCounter > cooldown) {
			attack ();
		}


	}
}
