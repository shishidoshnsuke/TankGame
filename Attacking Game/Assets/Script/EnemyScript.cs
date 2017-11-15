using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	int Count = 5;
	public int DestroyTime;
	public GameObject[] TargetHP = new GameObject[5];
	float Upspeed = 0.5f;

	bool isUp = true;

	public GameObject instantiate;
	public Transform target;
	public float speed = 10;

	public GameObject changeObj;
	public Material material1;
	public Material material2;
	int MaterialCount = 2;
	float timer = 0;
	float  interval = 0.5f;

	GameObject EnemyPrefab;
	GameObject[] Enemys;

	Material mat;

	// Use this for initialization
	void Start () {
		if (Enemys == null) {
			Enemys = GameObject.FindGameObjectsWithTag ("Player");
		}
		float minDistance = 10000;
		foreach (GameObject enemy in Enemys) {
			float distance = Vector3.Distance (this.transform.position, enemy.transform.position);
			if (distance < minDistance) {
				target = enemy.transform;
				minDistance = distance;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > interval) {
			MaterialCount -= 1;
			timer = 0;
			if (MaterialCount == 1) {
				changeObj.GetComponent<Renderer> ().material = material1;
			}
			if (MaterialCount == 0) {
				changeObj.GetComponent<Renderer> ().material = material2;
				MaterialCount += 2;
			}
		}

		this.transform.position += new Vector3 (0, 6 * Upspeed * Time.deltaTime, 0);
		if (this.transform.position.y > 6 && isUp == true) {
			isUp = false;
			Upspeed *= -1;
		} else if (this.transform.position.y < 2 && isUp == false) {
			isUp = true;
			Upspeed *= -1;
		}

		Destroy (this.gameObject, DestroyTime);

		Vector3 vec = (target.position - transform.position).normalized;
		transform.position += vec * speed * Time.deltaTime;
		transform.forward = -vec;

		if (Vector3.Distance (transform.position, target .transform.position) < 1.0f) {
			GameObject.Find ("Player_01").SendMessage ("PlayerDamage");
			Instantiate (instantiate, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Bullet") {
			Count -= 1;
			ChangeRed ();
			if (Count == 4) {
				Destroy (TargetHP[0]);
			}
			if (Count == 3) {
				Destroy (TargetHP[1]);
			}
			if (Count == 2) {
				Destroy (TargetHP[2]);
			}
			if (Count == 1) {
				Destroy (TargetHP[3]);
			}
			if (Count <= 0) {
				Destroy (TargetHP[4]);
				Instantiate (instantiate, transform.position, transform.rotation);
				Destroy (this.gameObject);
			}
		}
	}

	void ChangeRed(){
		SkinnedMeshRenderer[] skineds = GetComponentsInChildren<SkinnedMeshRenderer> ();
		foreach (SkinnedMeshRenderer skined in skineds) {
			skined.materials [0].color = Color.red;
			Invoke ("ChangeWhite",0.1f);
		}
	}

	void ChangeWhite(){
		SkinnedMeshRenderer[] skineds = GetComponentsInChildren<SkinnedMeshRenderer> ();
		foreach (SkinnedMeshRenderer skined in skineds) {
			skined.materials [0].color = Color.white;
		}
	}
}
