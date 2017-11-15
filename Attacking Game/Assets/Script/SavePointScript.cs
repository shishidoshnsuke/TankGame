using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePointScript : MonoBehaviour {

	public Transform target;
	float Count = 7;
	float timer = 0;
	float interval = 1;

	public GameObject changeObj;
	public Material material;

	public GameObject Target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, target.transform.position) <= 5.0f) {
			timer += Time.deltaTime;
			if (timer > interval) {
				Count -= 1;
				timer = 0;
			}
			if(Count <= 0) Count = 0;
			if(Count == 0){
				changeObj.GetComponent<Renderer>().material = material;
				GameObject.Find ("Player_01").SendMessage ("SavePoint");
			}
		}
	}
}