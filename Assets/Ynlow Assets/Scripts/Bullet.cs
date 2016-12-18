using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float velocity = 1;
	public float lifetime = 2;
	public Vector3 target = Vector3.zero;// = Vector3.zero;

	// Use this for initialization
	void Awake () {
//		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime < 0)
			Destroy (gameObject);
		transform.position += target * velocity;
		Debug.Log (target * velocity);

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			collider.GetComponent<Health> ().takeDamage (5);
		}
			Destroy (gameObject);
	}
}
