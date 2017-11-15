using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMouseScript : MonoBehaviour {

	public GameObject GameObject;
	float timer = 0;
	float interval = 0.1f;
	float speed = 100;
	Animator animator;

	void Start () {
		Screen.lockCursor = true;
		animator = GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetMouseButton(0)){
			timer += Time.deltaTime;
			if (timer > interval) {
				animator.SetBool ("Gun", true);
				Shot ();
				timer = 0;
			}
		} else {
			timer = 0;
			animator.SetBool ("Gun", false);
		}
	}

	void Shot(){
		// 弾を生成する、場所はPoint
		GameObject obj = Instantiate (GameObject , transform.position , transform.rotation) as GameObject;
		Destroy (obj, 10);
		// 弾に速度を与える。方向は前方向、スピードはbulletSpeed
		obj.GetComponent<Rigidbody> ().velocity = -transform.forward * -speed;
	}
}