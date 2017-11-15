using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

	public GameObject GameObject;
	public Transform target;
	public float speed = 50;

	GameObject EnemyPrefab;
	GameObject[] Enemys;

	void Start () {
		if (Enemys == null) {
			Enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		} else {
			//target = this.transform;
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

	void Update (){
		// (敵の位置 - 自分の位置)が向かうべき向き
		Vector3 vec = (target.position - transform.position).normalized;
		transform.position += vec * speed * Time.deltaTime;
		transform.forward = -vec;

		if (Vector3.Distance (transform.position, target .transform.position) < 1.0f) {
			Instantiate (GameObject, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter (Collision other){
		GameObject obj = Instantiate (GameObject, transform.position, transform.rotation) as GameObject;
		Destroy (this.gameObject);
	}
}