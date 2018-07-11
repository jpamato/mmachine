using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	//Input Events
	public static System.Action<Vector3,Vector3> OnPlacaAddEnd = delegate { };
	public static System.Action<Emisor> EditEmisor = delegate { };
	public static System.Action CloseEditor = delegate { };

}
