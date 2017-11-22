using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRightScript : MonoBehaviour {

	bool isUp = true;
	public float UPspeed = 5.0f;
	Vector3 firstPos;

	// Use this for initialization
	void Start () {
		firstPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += transform.right * UPspeed * Time.deltaTime;
		if (this.transform.position.x > firstPos.x + 5 && isUp == true) {
			isUp = false;
			UPspeed *= -1;
		} else if (this.transform.position.x < firstPos.x - 5 && isUp == false) {
			isUp = true;
			UPspeed *= -1;
		}
	}
}
