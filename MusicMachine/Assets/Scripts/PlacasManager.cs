using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacasManager : MonoBehaviour {

	public GameObject placa;
	public GameObject placasContainer;

	Vector3 placaIn,placaOut;
	bool addingPlaca;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Game.Instance.inputManager.mousePressed) {
			if (Game.Instance.inputManager.hasHit)
			if (Game.Instance.inputManager.hit.collider.tag == "PlanoPlaca") {
				placaIn = Game.Instance.inputManager.hit.point;
				addingPlaca = true;
			}
			//CreateBola (hit.point);
		} else {
			if (Game.Instance.inputManager.hasHit)
			if (Game.Instance.inputManager.hit.collider.tag == "PlanoPlaca") {
				if (addingPlaca) {
					placaOut = Game.Instance.inputManager.hit.point;
					CreatePlaca ();
					addingPlaca = false;
				}
			}
		}
	}

	void CreatePlaca(){
		Vector3 pos = placaIn + (placaOut - placaIn) * 0.5f;
		pos.z = placaOut.z;
		//Quaternion.Euler (Vector3.Angle (placaIn, placaOut));
		Vector3 a = placaIn-Camera.main.transform.position;
		Vector3 b = placaOut-Camera.main.transform.position;
		Vector3 dir = Vector3.Cross (a, b);

		GameObject go = GameObject.Instantiate (placa, pos, Quaternion.identity, placasContainer.transform);
		go.transform.LookAt (dir);
		Vector3 s = go.transform.localScale;
		go.transform.localScale = new Vector3 (Mathf.Abs(placaOut.x-placaIn.x),s.y,s.z);
	}
}
