using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEclipseInput : MonoBehaviour {
	public GameObject Earth;
	public bool success = false;
	private bool isEclipse;

	void Start () {
		isEclipse = GetComponent <CheckForEclipse>().isEclipse;
	}
	
	void FixedUpdate () {
		isEclipse = GetComponent <CheckForEclipse>().isEclipse;
	}

	void OnMouseOver(){ //can change this to player tap later
		print(isEclipse);
		if (Input.GetMouseButtonDown(0)) {
			if (isEclipse) {
				Debug.DrawRay (transform.position, Earth.transform.position, Color.green, 1f, true);
			} else {
				Debug.DrawRay (transform.position, Earth.transform.position, Color.red, 1f, true);
				success = false;
			}
		}	
	}
}
