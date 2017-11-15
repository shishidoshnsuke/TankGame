using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour {

	public float Count = 5;
	public float Time;
	public GameObject[] TargetHP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Count <= 0) {
			Destroy (this.gameObject,Time);
		}
	}

	void OnTriggerEnter (Collider col) {
		Count -= 1;
		if (col.gameObject.tag == "Bullet") {
			//transform.Find("TargetHP")は自分の子供からオブジェクトを探す
			transform.Find("TargetHP").SendMessage ("Damege");
		}
	}
}
