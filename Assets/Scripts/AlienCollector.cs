using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienCollector : MonoBehaviour {


	private Camera c; 


	// Use this for initialization
	void Start () {
		c = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// call check for touch here
		checkForTouch();
	}

	void checkForTouch () {
		if (Input.GetMouseButtonDown (0) && 
			(GetComponent<Collider2D> () == Physics2D.OverlapPoint (c.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 80f))))) 
			Debug.Log ("Alien is clicked.");
	}
}
