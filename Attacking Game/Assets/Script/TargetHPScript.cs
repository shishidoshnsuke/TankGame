using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetHPScript : MonoBehaviour {

	public GameObject Target1;
	public GameObject Target2;
	public GameObject Target3;
	public GameObject Target4;
	public GameObject Target5;
	float Count = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Damege () {
		Count -= 1;
		if (Count == 4) {
			Destroy (Target1);
		}
		if (Count == 3) {
			Destroy (Target2);
		}
		if (Count == 2) {
			Destroy (Target3);
		}
		if (Count == 1) {
			Destroy (Target4);
		}
		if (Count == 0) {
			Destroy (Target5);
		}
	}
}
