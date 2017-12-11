using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienCollector : MonoBehaviour {

	public float bonusSpeedRate;
	public bool collected;

	private Camera c; 
	private float timeSinceCollected;

	// Use this for initialization
	void Start () {
		c = Camera.main;
		timeSinceCollected = 0f;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// call check for touch here
		checkForTouch();

		if (collected) {
			timeSinceCollected += Time.deltaTime;
		}

		if (timeSinceCollected > 5f) {
			timeSinceCollected = 0f;
			collected = false;
		}
	}

	void checkForTouch () {
		if (Input.GetMouseButtonDown (0) &&
		    (GetComponent<Collider2D> () == Physics2D.OverlapPoint (c.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 80f)))))
			bonusSpeedRate = 0.3f;
			collected = true;
			Debug.Log ("Alien is clicked.");
	}
}
