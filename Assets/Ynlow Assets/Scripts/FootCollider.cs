﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {
	public bool inTheAir = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") {
			inTheAir = false;
		}
	}

}