using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunKeyScript : MonoBehaviour {

	public GameObject GameObject;
	int GunCount = 30;
	int Gun2Count = 150;
	float timer = 0;
	float interval = 0.1f;
	float speed = 100;
	Animator animator;

	public GameObject[] GunMissileCount = new GameObject[15];
	public Material material1;
	public Material material2;

	void Start () {
		Screen.lockCursor = true;
		animator = GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKey(KeyCode.J)){
			timer += Time.deltaTime;
			if (timer > interval) {
				if (GunCount >= 0) {
					animator.SetBool ("Gun", true);
					GunCount -= 1;
					GameObject obj = Instantiate (GameObject , transform.position , transform.rotation) as GameObject;
					obj.GetComponent<Rigidbody> ().velocity = -transform.forward * -speed;
					Destroy (obj, 10);
					timer = 0;
					if (GunCount <= 28) {
						GunMissileCount [(30 - GunCount) / 2 - 1].SetActive (false);
					}
				}
			}
		} else {
			if (GunCount >= 0) {
				timer = 0;
			}
			animator.SetBool ("Gun", false);
		}
		if (GunCount <= 0) {
			timer += Time.deltaTime;
			if (timer > interval) {
				Gun2Count -= 1;
				if (Gun2Count <= 140) {
					GunMissileCount [Gun2Count / 10].SetActive (true);
					GunMissileCount [Gun2Count / 10].GetComponent<Renderer> ().material = material2;
				}
				if (Gun2Count <= 0) {
					GunCount += 30;
					Gun2Count += 150;
					foreach (var g in GunMissileCount) {
						g.GetComponent<Renderer>().material = material1;
					}
				}
			}
		}
	}
}