using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalTargetScript : MonoBehaviour {

	public int Time = 5;
	public int Count = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, Time); 
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Bullet") {
			Count -= 1;
		}
		if (Count == 0) {
			Destroy (this.gameObject);
		}
	}
}
