using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public float speed = 2.0f;
	public float Rotationspeed = 5.0f;
	Quaternion rotation;
	float PlayerHPCount = 10;

	public GameObject Map;
	int MapCount = 2;

	public float SavePointCount = 5;
	public GameObject Gole;

	float timer = 0;
	float interval = 7;

	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) {
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey ("s")) {
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey ("a")) {
			rotation = rotation * Quaternion.Euler (0, -1, 0);
		}
		if (Input.GetKey ("d")) {
			rotation = rotation * Quaternion.Euler (0, 1, 0);
		}
		if (Input.GetKey ("up")) {
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey ("down")) {
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey ("left")) {
			rotation = rotation * Quaternion.Euler (0, -1, 0);
		}
		if (Input.GetKey ("right")) {
			rotation = rotation * Quaternion.Euler (0, 1, 0);
		}

		transform.rotation = Quaternion.Slerp (transform.rotation,　rotation,Rotationspeed*Time.deltaTime);

		if (this.transform.position.y <= -10) {
			this.transform.position += new Vector3 (0, 20, 0);
		}

		if (Input.GetKeyDown ("m")) {
			Map.SetActive(true);
			MapCount -= 1;
			if (MapCount <= 1) {
				Map.SetActive (false);
				MapCount += 2;
			}
		}
	}
		
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Goal") {
			SceneManager.LoadScene ("Goal");
		}
		if (col.gameObject.tag == "SpeedUP") {
			speed += 1.5f;
			timer += Time.deltaTime;
			if (timer > interval) {
				speed -= 1.5f;
				timer = 0;
			}
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "HPUP") {
			PlayerHPCount += 0.5f;
			//PlayerHPScript.PlayerHPCount += 0.5f;
			Destroy (col.gameObject);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") {
			PlayerHPCount -= 1;
			//PlayerHPScript.PlayerHPCount -= 1;
			if (PlayerHPCount == 0) {
				SceneManager.LoadScene ("GameOver");
			}
		}
	}

	void OnCollisionStay (Collision col) {
		if (col.gameObject.tag == "MoveFloor") {
			this.transform.position = new Vector3(col.gameObject.transform.position.x ,this.gameObject.transform.position.y,col.gameObject.transform.position.z);
		}
	}

	void SavePoint(){
		SavePointCount -= 1;
		if (SavePointCount <= 0) SavePointCount = 0;
		if (SavePointCount == 0){
			Gole.SetActive(true);
		}
	}
}