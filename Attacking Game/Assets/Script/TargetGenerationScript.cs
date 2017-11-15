using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerationScript : MonoBehaviour {

	public  GameObject GameObject;
	float timer = 0;
	public float interval = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= interval) {
			transform.position = new Vector3 (Random.Range (-20.0f, 20.0f), Random.Range (-3.0f, 13.0f), 55);
			Instantiate (GameObject, transform.position, transform.rotation);
			timer = 0;
		}
	}
}
