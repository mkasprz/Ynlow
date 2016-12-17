using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public Rigidbody2D rigid;
	public GameObject jumpButton;
	public FootCollider foots;

	// Use this for initialization
	void Awake () {

	}

	public void jump() {
		Debug.Log (GetComponent<Rigidbody2D> ());
		if (!foots.inTheAir)
		rigid.velocity = new Vector2 (0, 10);
		foots.inTheAir = true;
		//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (5, -5));
	}


//	void OnCollisionEnter(

	// Update is called once per frame
	void Update () {
//		Debug.Log ("FROM FATHER");
	}
}
