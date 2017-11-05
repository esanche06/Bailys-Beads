using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour {
	private PlayerEclipseInput sunScript;

	void Start () {
		sunScript = GameObject.Find ("Sun").GetComponent<PlayerEclipseInput>();
	}
	
	void FixedUpdate () {
		if (sunScript.failure) {
			gameObject.GetComponent<CanvasGroup> ().alpha = 1;
		}
	}
}
