using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LibPDBinding;

public class AdditiveController : MonoBehaviour {

	Material material;
	Color color;
	float dur;
	int nota;
	float vel;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		material = GetComponent<MeshRenderer> ().material;
		color = material.color;
		rb = GetComponent<Rigidbody> ();
		rb.Sleep ();


		ResetAdditive ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(){
		//additive.SendEvent(Hv_additive_example_AudioLib.Event.Play);
	}

	public void ResetAdditive(){
		vel = 0.25f + Random.value * 0.75f;
		gameObject.transform.localScale = new Vector3 (vel,vel,vel);


		nota = Random.Range (0, 6);

		color = Color.HSVToRGB (0.1f * nota, 1f, 1f);
		material.color = color;
		dur = 1f/Random.Range (1, 16);

		rb.drag = dur;
		rb.WakeUp ();
	}

	void OnCollisionEnter(Collision collision) {
		if (enabled&&collision.collider.tag == "Placa") {
			LibPD.SendFloat ("dur", dur);
			LibPD.SendFloat ("vel", vel);
			LibPD.SendFloat ("note", nota * 2 + 60);

			material.color = Color.red;
			LibPD.SendBang ("play");
			Invoke ("ResetColor", dur);
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
