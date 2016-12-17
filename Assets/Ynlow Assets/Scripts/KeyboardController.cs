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
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump ();
		}
		cooldownCounter += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.LeftAlt) && cooldownCounter > cooldown) {
			attack ();
		}


		if (tmp > 0) {
			tmp -= Time.deltaTime;
			if(tmp <= 0)
				transform.localScale -= new Vector3 (0.4f,0.4f,0);
		}

	}
}
