using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health = 50;
	float maxHealth = 50;
	float firsSize;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		firsSize = healthBar.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.transform.localScale = new Vector3(health / maxHealth * firsSize, healthBar.transform.localScale.y, 0);
		if (health <= 0)
			Destroy (gameObject);
	}

	public void takeDamage(int damage) {
		health -= damage;
	}
}
