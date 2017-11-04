using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEclipseInput : MonoBehaviour {
	public GameObject Earth;
	public bool failure = false;
	public float score = 0;
	private float timeLeft = 60;
	private float bonus = 1;
	private bool isEclipse;

	void Start () {
		// Set starting alignment boolean
		isEclipse = GetComponent <CheckForEclipse>().isEclipse;
	}
	
	void FixedUpdate () {
		// Action for frame updates

		// Set Alignment Boolean
		isEclipse = GetComponent <CheckForEclipse>().isEclipse;

		// Countdown timer for score bonus
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			bonus = 1;
		} else {
			bonus = timeLeft;
		}
	}
			

	void OnMouseOver() {
		// Tap feature on Sun Asset
		if (Input.GetMouseButtonDown(0)) {
			if (isEclipse) {
				score += 1;
				failure = false;
				Debug.Log (score);
				Debug.DrawRay (transform.position, Earth.transform.position, Color.green, 1f, true);
			} else {
				failure = true;
				score = 0;
				Debug.DrawRay (transform.position, Earth.transform.position, Color.red, 1f, true);
			}
		}	
	}
}
