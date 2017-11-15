using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play () {
		Application.LoadLevel ("Stage_01");
	}

	public void Stage_02 () {
		Application.LoadLevel ("Stage_02");
	}
}
