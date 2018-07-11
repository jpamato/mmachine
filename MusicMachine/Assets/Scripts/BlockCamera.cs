using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCamera : MonoBehaviour {

	public GameObject mask;

	void Start () {
		Events.EditEmisor += Block;
		Events.CloseEditor += Unblock;
	}

	void OnDestroy(){
		Events.EditEmisor -= Block;
		Events.CloseEditor -= Unblock;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Block(Emisor e){
		mask.SetActive (true);
	}

	void Unblock(){
		mask.SetActive (false);
	}
}
