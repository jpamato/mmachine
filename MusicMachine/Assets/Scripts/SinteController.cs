using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class SinteController : MonoBehaviour {

	Material material;
	Color color;
	float dur;
	public int nota;
	float vel;
	Rigidbody rb;

	public int index;

	Emisor emisor;

	// Use this for initialization
	void Start () {
		

		//ResetAdditive ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(){
		//additive.SendEvent(Hv_additive_example_AudioLib.Event.Play);
	}

	public void ResetAdditive(Emisor e){

		emisor = e;

		material = GetComponent<MeshRenderer> ().material;
		color = material.color;
		rb = GetComponent<Rigidbody> ();
		rb.Sleep ();

		vel = emisor.gain;
		gameObject.transform.localScale = new Vector3 (vel*0.5f,vel*0.5f,vel*0.5f);


		//nota = Random.Range (0, 6);
		int shLength = System.Enum.GetValues(typeof(ShapesMachine.Shape)).Length;
		color = Color.HSVToRGB (1f*(index%shLength)/shLength, 1f, 1f);
		material.color = color;
		dur = emisor.dur;

		rb.drag = dur*0.001f;
		rb.WakeUp ();
	}

	void OnCollisionEnter(Collision collision) {
		if (enabled) {
			//Debug.Log("dur: "+dur+" - amp: "+ vel+" - note: "+ (nota*2+60));
			Placa p = collision.collider.GetComponent<Placa>();
			//Debug.Log (p.note);
			if (p != null) {
				LibPD.SendFloat ("dur"+index, dur*emisor.art*1000);
				//LibPD.SendFloat ("envOut"+index, (dur-(dur*emisor.art)) * 1000);
				LibPD.SendFloat ("vel"+index, 127 * vel * 1f);
				LibPD.SendFloat ("har"+index, emisor.har);
				LibPD.SendFloat ("modIn"+index, emisor.iMod);
				LibPD.SendFloat ("note"+index, p.note);

				if (emisor.decay > 0) {
					vel *= emisor.decay;
					gameObject.transform.localScale = new Vector3 (vel*0.5f,vel*0.5f,vel*0.5f);
				}

				material.color = Color.white;
				//LibPD.SendBang ("play");
				Invoke ("ResetColor", dur);
			}
		}
	}

	void ResetColor(){
		material.color = color;
	}

	void OnBecameInvisible(){
		//rb.Sleep ();
		Destroy (gameObject, 1f);
	}

}
