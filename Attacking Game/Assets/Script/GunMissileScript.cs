using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMissileScript : MonoBehaviour {

	public GameObject GameObject;
	public float GunCount = 1;
	float GunCount2 = 7;
	float timer = 0;
	float interval = 1;
	float speed = 30;
	float MissileCount = 5;

	public GameObject[] GunMissileCount = new GameObject[5];

	void Start () {
		Screen.lockCursor = true;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.K)){
			if(GunCount == 1){
				GunCount -= 1;
				GameObject obj = Instantiate (GameObject , transform.position , transform.rotation) as GameObject;
				obj.GetComponent<Rigidbody> ().velocity = -transform.forward * -speed;
				Destroy (obj, 10);
				GunMissileCount [0].SetActive (false);
				GunMissileCount [1].SetActive (false);
				GunMissileCount [2].SetActive (false);
				GunMissileCount [3].SetActive (false);
				GunMissileCount [4].SetActive (false);
			}
		}
		if (GunCount <= 0) {
			timer += Time.deltaTime;
			if (timer > interval) {
				timer = 0;
				GunCount2 -= 1;
				if (GunCount2 == 6) {
					GunMissileCount[0].SetActive (true);
				}
				if (GunCount2 == 5) {
					GunMissileCount[1].SetActive (true);
				}
				if (GunCount2 == 4) {
					GunMissileCount[2].SetActive (true);
				}
				if (GunCount2 == 3) {
					GunMissileCount[3].SetActive (true);
				}
				if (GunCount2 == 2) {
					GunMissileCount[4].SetActive (true);
				}
				if (GunCount2 == 1) {
					GunCount += 1;
					GunCount2 += 6;
				}
			}
		}
	}
}