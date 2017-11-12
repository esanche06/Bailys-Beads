using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEclipseInput : MonoBehaviour {
	public GameObject Earth;
	public CanvasGroup flashCanvas;
	public bool failure = false;
	public float score = 0;

	private float timeLeft = 60;
	private float bonus = 1;
	private bool isEclipse;
	private bool successFlash = false;
	private bool failureFlash = false;
	private bool flashEnded = false;
	private Image flashPanel;

	void Start () {
		// Set starting alignment boolean
		isEclipse = GetComponent <CheckForEclipse>().isEclipse;
		flashPanel = GameObject.Find ("Flash").GetComponent<Image> ();
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

		//If success or failure, flash the screen
		if (successFlash || failureFlash) {
			if (!flashEnded) {
				flashEnded = flash ();
			} else {
				successFlash = false;
				failureFlash = false;
				flashEnded = false;
			}
		}
	}

	void OnMouseOver() {
		// Tap feature on Sun Asset
		if (Input.GetMouseButtonDown(0) && !failure) {
			if (isEclipse) {
				score += 1;
				//Debug.Log (score);
				rayDebug (Color.green);
				successFlash = true;
				flashCanvas.alpha = 1;
			} else {
				failure = true;
				score = 0;
				rayDebug (Color.red);
				failureFlash = true;
				flashPanel.color = Color.red;
				flashCanvas.alpha = 1;
			}
		}	
	}

	private bool flash(){
		//Used in fixedUpdate to create delayed flash
		flashCanvas.alpha = flashCanvas.alpha - Time.deltaTime;
		if (flashCanvas.alpha <= 0) {
			flashCanvas.alpha = 0;
			flashEnded = true;
		} else {
			flashEnded = false;
		}
		return flashEnded;
	}

	private void rayDebug(Color color){
		Debug.DrawRay (transform.position, Earth.transform.position, color, 1f, true);
	}
}
