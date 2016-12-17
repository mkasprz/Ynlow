using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void move(float speed) {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//Debug.Log (move);
		transform.position += move * speed * Time.deltaTime;
	}
	public 

	// Update is called once per frame
	void Update () {

	}
}
