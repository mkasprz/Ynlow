using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : Controller {

	GameObject jumpButton;

	private bool moving = false;

	// Use this for initialization
	void Awake () {
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		jumpButton = GameObject.Find ("JumpButton");
		jumpButton.SetActive (true);
	}
	public void move(float speed) {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//Debug.Log (move);
		transform.position += move * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			transform.Translate (-touchDeltaPosition.x, -touchDeltaPosition.y, 0);
		}

	}
}
