using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnFail : MonoBehaviour {
	public bool gameFailed = false;

	private GameController gc;

	void Start(){
		gc = GameObject.Find ("GameController").GetComponent<GameController>();
		gameFailed = gc.gameFailed;
	}

	void FixedUpdate(){
		// Stop the rotation
		if (gc.gameFailed && (gameObject.name == "Earth" || gameObject.name == "Moon"))
			GetComponent<Orbit> ().speed = 0;
		else if (gc.gameFailed && gameObject.name == "Asteroid(Clone)")
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}


}
