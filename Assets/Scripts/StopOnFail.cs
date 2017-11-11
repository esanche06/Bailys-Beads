using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnFail : MonoBehaviour {
	private PlayerEclipseInput sunScript;

	void Start(){
		sunScript = GameObject.Find ("Sun").GetComponent<PlayerEclipseInput>();
	}

	void FixedUpdate(){
		// Stop the rotation
		if (sunScript.failure)
			GetComponent<Orbit>().speed = 0;
	}


}
