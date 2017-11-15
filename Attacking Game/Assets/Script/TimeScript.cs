using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

	float timer = 0;
	float interval = 1;
	public Text Scorelabel;
	public static float TimeCount = 500;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Scorelabel.text = TimeCount.ToString ();
		timer += Time.deltaTime;
		if (timer > interval) {
			TimeCount -= 1;
			timer = 0;
		}

		if (TimeCount >= 0) {
			
		}
	}
}