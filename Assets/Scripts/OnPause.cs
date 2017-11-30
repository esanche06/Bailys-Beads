using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : MonoBehaviour {
	public bool pausePressed, resumePressed;

	private bool pauseStarted;

	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			GameObject child = transform.GetChild (i).gameObject;
			if(child.name != "PauseButton")
				child.SetActive (false);
		}
		pausePressed = false;
		pauseStarted = false;
		resumePressed = false;
	}
	
	void Update () {
		if (pausePressed && !pauseStarted) {
			resumePressed = false;
			pauseStarted = true;

			for (int i = 0; i < transform.childCount; i++) {
				GameObject child = transform.GetChild (i).gameObject;
				if(child.name != "PauseButton")
					child.SetActive (true);
				else 
					child.SetActive (false);
			}
		}

		if (resumePressed) {
			pausePressed = false;
			pauseStarted = false;

			for (int i = 0; i < transform.childCount; i++) {
				GameObject child = transform.GetChild (i).gameObject;
				if(child.name != "PauseButton")
					child.SetActive (false);
				else
					child.SetActive (true);
			}

		}
	}
}
