using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingCamera : MonoBehaviour {

	public GameObject targeted;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(targeted.transform.position.x, targeted.transform.position.y, transform.position.z);
	}
}
