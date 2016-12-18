using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : Controller {

	public GameObject attackButton;
	private bool mov = false;
	public AndroidJoystick a;

	private bool moving = false;

	// Use this for initialization
	void Awake () {
		//a = moveButton.GetComponent<AndroidJoystick>();
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	public void move(float speed) {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//Debug.Log (move);
		transform.position += move * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		cooldownCounter += Time.deltaTime;
		Vector2 pos;
		if (Input.touchCount > 1) {
			pos = Input.GetTouch(1).position;
			RaycastHit2D hit2 = Physics2D.Raycast (pos, Vector2.zero);
			if (hit2 != null && hit2.collider != null)
			if (hit2.collider == attackButton.GetComponent<CircleCollider2D> () && cooldownCounter > cooldown)
				attack ();
		}
		if (Input.touchCount > 0) {
			pos = Input.GetTouch(0).position;
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
			if (hit != null && hit.collider != null) {//(!mov) {
				if (hit.collider == a.gameObject.GetComponent<CircleCollider2D> () && !mov)
					mov = true;
				else if (hit.collider == attackButton.GetComponent<CircleCollider2D> () && cooldownCounter > cooldown)
					attack ();
			}
			if (mov) {
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
				if(Vector3.Distance (a.standardPosition, a.transform.position+new Vector3(touchDeltaPosition.x, 0, 0)) < 50)
					a.transform.position +=new Vector3(touchDeltaPosition.x, 0, 0);
				if(Vector3.Distance (a.standardPosition, a.transform.position+new Vector3(0, touchDeltaPosition.y*2, 0)) < 51)
					a.transform.position +=new Vector3(0, touchDeltaPosition.y*2, 0);
			}
		} else {
			if (mov) {
				mov = false;
				a.transform.position = a.standardPosition;
			}
		}
		float mySpeed = a.transform.position.x - a.standardPosition.x;
		Vector3 move = new Vector3(mySpeed/30,0,0);
		makeMove (move);
		//transform.position += move * speed * Time.deltaTime;

		float jumpModificator = a.transform.position.y - a.standardPosition.y;
		if (jumpModificator > 10) {
			jump ();
		}
	}
}
