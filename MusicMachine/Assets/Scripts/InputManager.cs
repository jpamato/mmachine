using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	public RaycastHit hit;
	public string hitName;
	public bool mousePressed;
	public bool hasHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (!mousePressed) {
				mousePressed = true;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				hasHit = Physics.Raycast (ray, out hit);
				if (hasHit) {
					hitName = hit.collider.name;
					if (hit.collider.tag == "Untagged") {
						hit = new RaycastHit ();
						hasHit = false;
					}
				}
			}
		} else {
			if (mousePressed) {
				if (hasHit) {
					if (hit.collider.tag == "PlanoPlaca") {
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						hasHit = Physics.Raycast (ray, out hit);
						if (hasHit)
							hitName = hit.collider.name;
					}
				}
				mousePressed = false;
			}
		}
	}
	

}
