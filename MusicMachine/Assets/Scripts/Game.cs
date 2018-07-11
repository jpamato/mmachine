using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	static Game mInstance = null;
	public InputManager inputManager;
	public GameManager gameManager;
	public ShapesMachine shapesMachine;

	public static Game Instance {
		get
		{
			return mInstance;
		}		
	}

	void Awake () {
		mInstance = this;
		inputManager = GetComponent<InputManager> ();
		gameManager = GetComponent<GameManager> ();
		shapesMachine = GetComponent<ShapesMachine> ();
	}
}
