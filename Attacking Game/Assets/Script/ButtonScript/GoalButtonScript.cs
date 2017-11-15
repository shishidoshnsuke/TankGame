using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Title () {
		Application.LoadLevel ("Title");
	}

	public void Stage1 () {
		Application.LoadLevel ("Stage1");
	}

	public void Stage2 () {
		Application.LoadLevel ("Stage2");
	}
}
