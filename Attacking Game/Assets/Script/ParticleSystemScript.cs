using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

	public int Count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 4);

	}


	void OnTriggerEnter (Collider col) {
		if (Count == 0) {
			if (col.gameObject.tag == "Enemy") {
				col.gameObject.SendMessage ("EnemyDamege");
			}
			if (col.gameObject.tag == "Player") {
				col.gameObject.SendMessage ("PlayerDamege");
			}
		}
	}
}
