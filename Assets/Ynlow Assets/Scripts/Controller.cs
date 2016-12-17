using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public Rigidbody2D rigid;
	public GameObject jumpButton;

	// Use this for initialization
	void Awake () {

	}

	public void jump() {
		Debug.Log (GetComponent<Rigidbody2D> ());
		rigid.velocity = new Vector2 (0, 5);
		//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (5, -5));
	}


	public 

	// Update is called once per frame
	void Update () {

	}
}
