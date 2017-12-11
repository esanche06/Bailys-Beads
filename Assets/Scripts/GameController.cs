using System;
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
    public Text gameOverText;
    public Text timeLeftText;
	public AudioSource successSource;
	public AudioClip successClip;
	
	private Camera c; 
	private Image flashPanel; 
	private RaycastHit2D[] results;
	private ContactFilter2D filter;
	private Vector3 dir;
	public float bonus = 1f,TimeLimit;
	private bool successFlash = false, failureFlash = false, flashEnded = false, checkingForFailure = true;
    string highScoreKey = "HighScore";

    public System.DateTime startTime;
    public float timeLeft;

    void Start () {
        startTime = DateTime.Now;
		score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = "H i g h   S c o r e : " + highScore;
        level = 1;
        TimeLimit = (100 / level); //Adding 5 secs of cusion time in case the 100/level leads to very less time like 2 seconds or something. 
        timeLeftText.text = "Time  Left : " + (int)TimeLimit;
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
            TimeSpan timeLefttemp = DateTime.Now - startTime;
            timeLeft = Convert.ToSingle(timeLefttemp.TotalSeconds);
            if (TimeLimit - timeLeft < 10)
            {
                timeLeftText.color = Color.red;
            }
            else
            {
                //timeLeftText.color = Color.white;
            }
            timeLeftText.text = "Time  Left : " + (int) (TimeLimit - timeLeft);
			if (TimeLimit - timeLeft < 0) {
                gameFailed = true;
                checkingForFailure = false;
                failure();
                gameOverText.text = "OUT OF TIME!";
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
		score +=  multiplier * (int) timeLeft ;
        //if (!flashEnded)
        //{
        //    score += 1000 * level;
        //}
		scoreText.text = "S c o r e : " + score;
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "H i g h   S c o r e : " + highScore;
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }

        level += 1;
        startTime = DateTime.Now;
        TimeLimit = (100 / level) + 5; //Adding 5 secs of cusion time in case the 100/level leads to very less time like 2 seconds or something. 

        
    }

}
