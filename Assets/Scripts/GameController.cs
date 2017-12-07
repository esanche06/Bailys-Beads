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
	public int score, level, highScore;
	public Text scoreText;
    public Text highScoreText;
	public AudioSource successSource;
	public AudioClip successClip;
	
	private Camera c; 
	private Image flashPanel; 
	private RaycastHit2D[] results;
	private ContactFilter2D filter;
	private Vector3 dir;
	private float bonus = 1f, timeLeft = 60f;
	private bool successFlash = false, failureFlash = false, flashEnded = false, checkingForFailure = true;
    string highScoreKey = "HighScore";


    void Start () {
		score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = "High Score: " + highScore;
        level = 1;
		results = new RaycastHit2D[3];
		filter = new ContactFilter2D ();
		filter.useTriggers = false; //Probably going to actually add filters later but not right now
		distance = Vector3.Distance(transform.position, Earth.transform.position);

		flashPanel = GameObject.Find ("Flash").GetComponent<Image> ();
		c = Camera.main;

		successSource = GetComponent<AudioSource> ();
		successSource.clip = successClip;
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
			Sun.GetComponent<Collider2D> () == Physics2D.OverlapPoint(c.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 80f)))) {
			if (isEclipse) {
				updateScore();
				//rayDebug (Color.green);
				successFlash = true;
				flashCanvas.alpha = 1;
				successSource.Play ();
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
		int multiplier = 100*level*level;
		score = multiplier;
		scoreText.text = "Score: " + score;
		level += 1;
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
    }

}
