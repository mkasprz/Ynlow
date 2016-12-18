using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {
	public bool inTheAir = false;
	public float jumpTime = 0;
	public float killTime = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inTheAir)
			jumpTime += Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") {
			inTheAir = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") {
			inTheAir = false;
		}
		if (jumpTime > killTime)
			GetComponentInParent<Health> ().takeDamage ((int)(jumpTime*20));
		jumpTime = 0;
		//Debug.Log (GetComponentInParent<Rigidbody2D>().velocity.y);
		//if (GetComponentInParent<Rigidbody2D>().velocity.y
	}
	void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") {
			jumpTime = 0;
			inTheAir = true;
		}
	}

}
