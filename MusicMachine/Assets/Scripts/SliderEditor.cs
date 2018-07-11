using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEditor : MonoBehaviour {

	public GameObject container;
	public GameObject emisorUI_container;
	EmisorUI emisorUI;

	// Use this for initialization
	void Start () {
		emisorUI = emisorUI_container.GetComponent<EmisorUI> ();

		Events.EditEmisor += EditEmisor;
	}

	void OnDestroy(){
		Events.EditEmisor -= EditEmisor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void EditEmisor(Emisor e){
		container.SetActive (true);
		emisorUI_container.SetActive (true);
		emisorUI.SetEmisor (e);
	}

	public void Close(){
		container.SetActive (false);
		emisorUI_container.SetActive (false);
		Events.CloseEditor ();
	}
}
