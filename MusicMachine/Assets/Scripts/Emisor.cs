using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emisor : MonoBehaviour {

	public int id;
	//public Slider type;
	//public Slider speed;
	public ShapesMachine shMachine;
	public ShapesMachine.Shape shape;

	public float dur,art,gain,decay,har,iMod;

	public GameObject blockCollider;

	public float tempo;

	public float zPos;

	float timer;
	float factor;

	// Use this for initialization
	void Start () {
		shMachine = Game.Instance.GetComponent<ShapesMachine> ();
		factor = 60f/tempo;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= (dur*factor)) {
			shMachine.SetShape (shape);
			shMachine.CreateShape (transform.position, this);
			timer = 0f;
		}
	}

	/*public void OnTypeChange(){
		shape = (ShapesMachine.Shape)type.value;
	}*/

	public void Delete(){
		Debug.Log ("aca");
		Destroy (blockCollider);
		Destroy (gameObject);
	}

	public void Edit(){
		Events.EditEmisor (this);
	}

}
