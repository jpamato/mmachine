using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmisorUI : MonoBehaviour {

	public Emisor emisor;

	public Slider type;
	public Slider dur;
	public Slider art;
	public Slider decay;
	public Slider gain;
	public Slider har;
	public Slider iMod;

	public float durQ;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetEmisor(Emisor e){
		emisor = e;
		type.value = (int)emisor.shape;
		dur.value = emisor.dur*durQ;
		har.value = emisor.har;
		iMod.value = emisor.iMod;
		decay.value = emisor.decay;
		gain.value = emisor.gain;
	}

	public void OnTypeChange(){
		emisor.shape = (ShapesMachine.Shape)type.value;
	}

	public void OnDurChange(){
		emisor.dur = dur.value/durQ;
	}

	public void OnArtChange(){
		emisor.art = art.value;
	}

	public void OnHarChange(){
		emisor.har = har.value;
	}

	public void OnIModChange(){
		emisor.iMod = iMod.value;
	}

	public void OnDecayChange(){
		emisor.decay = decay.value;
	}

	public void OnGainChange(){
		emisor.gain = gain.value;
	}
}
