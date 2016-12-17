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

	public float tmp = 0;

	// Use this for initialization
	void Awake () {

	}

	public void jump() {
		Debug.Log (GetComponent<Rigidbody2D> ());
		if (!foots.inTheAir)
			rigid.velocity = new Vector2 (0, jumpHigh);
		foots.inTheAir = true;
		//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (5, -5));
	}

	public void makeMove(Vector3 move) {
		transform.position += move * speed * Time.deltaTime;
	}

	public void attack() {
		cooldownCounter = 0;
		transform.localScale += new Vector3 (0.4f,0.4f,0);
		tmp = cooldown;
	}


//	void OnCollisionEnter(

	// Update is called once per frame
	void Update () {
		
//		Debug.Log ("FROM FATHER");
	}
}
