using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public Rigidbody2D rigid;
	public GameObject jumpButton;
	public FootCollider foots;
	public float speed = 5;
	public float jumpHigh = 10;
	public float cooldown = 0.3f;
	public float cooldownCounter = 0;
	public float mo;

	private bool inputEnabled = true;

	void Awake () {

	}

	public void enableInput() {
		inputEnabled = true;
	}
	public void disableInput() {
		inputEnabled = false;
	}

	public void jump() {
		if (inputEnabled) {
			if (!foots.inTheAir)
				rigid.velocity = new Vector2 (0, jumpHigh);
			foots.inTheAir = true;
		}
	}

	public void makeMove(Vector3 move) {
		mo = Mathf.Abs (move.x);
		if (inputEnabled) {
			rigid.velocity = new Vector2 ((move * speed * 1.5f).x, rigid.velocity.y);
		}
	}

	public void attack() {
		GetComponent<Health> ().takeDamage (10);
		cooldownCounter = 0;
	}
		
	void Update () {

	}
		
}
