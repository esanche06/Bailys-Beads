using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthOrbit : MonoBehaviour {
	public float alpha = 0f;
	public float tilt = 45f;

	void Start () {
		InvokeRepeating ("Orbit", 0, .07f);
	}

	void Update () {
		//Nothing yet
	}

	float MCos(float val){
		return Mathf.Cos(Mathf.Deg2Rad * val);
	}

	float MSin(float val){
		return Mathf.Sin(Mathf.Deg2Rad * val);
	}

	void Orbit(){
		transform.position = new Vector3 (
			0f + (10f * MCos(alpha) * MCos(tilt)) - ( 5f * MSin(alpha) * MSin(tilt)),
			0,
			0f + (10f * MCos(alpha) * MSin(tilt)) + ( 5f * MSin(alpha) * MCos(tilt)));
		alpha += 5f;
	}
}
