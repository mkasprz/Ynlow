using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	public Health killHim;
	public Character visible;
	public int killDistance = 3;
	public int damage = 1;
	public int patrolBuffer = 3;
	public int velocity = 2;
	public GameObject bulletPrefab;
	public float cooldown = 10.0f;
	public float cooldownCounter;
	public bool seeMee = false;
	public float dezorientation = 2;
	int dir = 0;

	private float sowMe = 0.0f;
	private Vector3 startingPoint;
	private Rigidbody2D rigid;
	private bool right = true;

	// Use this for initialization
	void Start() {
		killHim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health>();
		visible = GameObject.FindGameObjectWithTag ("Player").GetComponent<Character>();
	}

	void Awake () {
		rigid = GetComponent<Rigidbody2D> ();
		startingPoint = transform.position;
		cooldownCounter = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		cooldownCounter += Time.deltaTime;
		if (!seeMee && right) {
			if (transform.position.x > (startingPoint.x + patrolBuffer)) {
				right = !right;
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			} else {
				rigid.velocity = new Vector2 (velocity, rigid.velocity.y);
			}
		}
		if (!seeMee && !right) {
			if (transform.position.x < (startingPoint.x - patrolBuffer)) {
				right = !right;
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			} else {
				rigid.velocity = new Vector2 (-velocity, rigid.velocity.y);
			}
		}
		if (Vector3.Distance (killHim.gameObject.transform.position, transform.position) < killDistance && !visible.hidden) {
			//Debug.Log (transform.position + "  :  " + killHim.transform.position);
			if (!seeMee) {
				seeMee = true;
				sowMe = 0;
			} else {
				sowMe += Time.deltaTime;
			}
			if (killHim.transform.position.x >= transform.position.x)
				right = true;
			else
				right = false;
			if (right)
				dir = 1;
			else
				dir = -1;
			if (sowMe > dezorientation && cooldownCounter > cooldown) {
				GameObject bullet = Instantiate (bulletPrefab, transform.position + new Vector3 (dir, 0, 0), transform.rotation);
				bullet.GetComponent<Bullet> ().target = killHim.transform.position-(transform.position + new Vector3 (dir, 0, 0));
				cooldownCounter = 0;
			}
		} else
			seeMee = false;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Sword") {
			GetComponent<EnemyHealth> ().takeDamage (10);
		}
	}

}
