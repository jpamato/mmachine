using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesMachine : MonoBehaviour {	
	
	public Transform shapesContainer;
	public GameObject bola;
	public GameObject cubo;
	public GameObject capsula;
	public GameObject cilindro;
	public GameObject emisorColBlock;
	public GameObject emisorUI;
	public Canvas canvas;

	public int index;
	public List<Emisor> emisores;

	GameObject selShape;
	bool emitted;

	Shape shape;
	public enum Shape{
		BOLA,
		CUBO,
		CAPSULA,
		CILINDRO
	}

	// Use this for initialization
	void Start () {
		shape = Shape.BOLA;
		SetShape ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Game.Instance.inputManager.mousePressed) {
			if (Game.Instance.inputManager.hasHit) {
				if (Game.Instance.inputManager.hit.collider.tag == "PlanoEmisor") {
					if (!emitted) {
						CreateEmisor (Game.Instance.inputManager.hit.point);
						emitted = true;
					}
				}
			}			
			//CreateBola (hit.point);
		} else {
			emitted = false;

		}
	}

	public void CreateShape(){
		GameObject.Instantiate (bola, new Vector3 (Random.Range (-3, 3), 6f, 0f), Quaternion.identity, shapesContainer);
	}

	public void CreateShape(Vector3 pos, Emisor e){
		GameObject go = GameObject.Instantiate (selShape, pos, Quaternion.identity, shapesContainer);
		go.GetComponent<SinteController> ().ResetAdditive (e);
	}

	public void CreateEmisor(Vector3 pos){
		GameObject eUI = GameObject.Instantiate (emisorUI, pos, Quaternion.identity, canvas.transform);
		Emisor e = eUI.GetComponent<Emisor> ();
		e.id = index;
		e.blockCollider = GameObject.Instantiate (emisorColBlock, pos, Quaternion.identity, shapesContainer);
		emisores.Add (e);
		index++;
	}

	public void SetShape(Shape s){
		shape = s;
		SetShape ();
	}

	public void SetShape(){
		if (shape == Shape.BOLA) {
			selShape = bola;
		}else if (shape == Shape.CUBO) {
			selShape = cubo;
		}else if (shape == Shape.CAPSULA) {
			selShape = capsula;
		}else if (shape == Shape.CILINDRO) {
			selShape = cilindro;
		}

	}
}
