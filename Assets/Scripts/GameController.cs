using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject Sun;
	public GameObject Earth;
	public GameObject Moon;
	public CanvasGroup flashCanvas;
	public float distance = 1;
	public bool isEclipse = false, gameFailed = false;
	public int score;
	public GUIText scoreText;
	private Image flashPanel;
	private RaycastHit2D[] results;
	private ContactFilter2D filter;
	private Vector3 dir;
	private float bonus = 1f, timeLeft = 60f;
	private bool successFlash = false, failureFlash = false, flashEnded = false, checkingForFailure = true; 
	private Camera c;

	void Start () {
		score = 0;
		updateScore();
		results = new RaycastHit2D[3];
		filter = new ContactFilter2D ();
		filter.useTriggers = false; //Probably going to actually add filters later but not right now
		distance = Vector3.Distance(transform.position, Earth.transform.position);

		flashPanel = GameObject.Find ("Flash").GetComponent<Image> ();

		c = Camera.main;
	}

	void FixedUpdate () {
		if (!gameFailed) {
			if (Physics2D.Raycast (transform.position, Earth.transform.position, filter, results, distance) > 2)
				isEclipse = true;
			else
				isEclipse = false;

			// Countdown timer for score bonus
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				bonus = 1;
			} else {
				bonus = timeLeft;
			}
		}

		if(checkingForFailure)
			checkForFailure ();

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

	void checkForFailure(){
		if (!gameFailed 					&&
			Input.GetMouseButtonDown (0) 	&&
			Sun.GetComponent<Collider2D>() == Physics2D.OverlapPoint(c.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 80f)))) {
			if (isEclipse) {
				score += 1;
				updateScore();
				//rayDebug (Color.green);
				successFlash = true;
				flashCanvas.alpha = 1;
			} else {
				gameFailed = true;
				checkingForFailure = false;
				failure ();
			}
		} else if (gameFailed) {
			checkingForFailure = false;
			failure();
		}
	}

	void failure(){
		score = 0;
		//rayDebug (Color.red);
		failureFlash = true;
		flashPanel.color = Color.red;
		flashCanvas.alpha = 1;
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
	
	void updateScore()
	{
		scoreText.text = "Score: " + score;
	}

}
