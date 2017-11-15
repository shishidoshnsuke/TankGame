using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	public Transform target;

	// Use this for initialization
	void Start () {
		target = target.transform;
	}
	
	// Update is called once per frame
	void Update () {

		/*//ドラッグ時のマウス位置を変数に格納
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;

		Debug.Log (x.ToString () + " - " + y.ToString ());

		//ドラッグ時のマウス位置をシーン上の3D空間の座標に変換する
		Vector3 currentScreenPoint = new Vector3 (x, y, 50);

		//上記にクリックした場所の差を足すことによって、オブジェクトを移動する座標位置を求める
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint);

		Vector3 pos = Camera.main.ScreenToWorldPoint (currentScreenPoint);
		Debug.Log (pos);
		transform.LookAt (pos);*/

		transform.LookAt (target);
	}
}
