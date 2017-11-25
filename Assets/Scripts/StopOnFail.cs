using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnFail : MonoBehaviour {
	public bool gameFailed = false;
	public AudioSource failureSource;
	public AudioClip failureClip;

	private GameController gc;
	private bool isPlayAudio = true;

	void Start(){
		gc = GameObject.Find ("GameController").GetComponent<GameController>();
		gameFailed = gc.gameFailed;
		if (gameObject.name == "Asteroid(Clone)") {
			// Added an AudioSource to all new instantiation of Asteroid Clone
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		}
		failureSource = GetComponent<AudioSource> ();
		failureSource.clip = failureClip;
	}

	void FixedUpdate(){
		// Stop the rotation
		if (gc.gameFailed && (gameObject.name == "Earth" || gameObject.name == "Moon")) {
			GetComponent<Orbit> ().speed = 0;
			if (isPlayAudio) {
				PlaySound ();
			}
		}
		else if (gc.gameFailed && gameObject.name == "Asteroid(Clone)")
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}

	void PlaySound() {
		// Play Audio Sound for Failure once
		failureSource.Play ();
		isPlayAudio = false;
	}
}
