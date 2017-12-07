using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
	public AudioSource bgMusicSource;
	public AudioClip bgMusicClip;

	private AudioController audioController;


	void Start () {
		// Start Playing Background Music for Game
		bgMusicSource = GetComponent<AudioSource> ();
		bgMusicSource.clip = bgMusicClip;
		bgMusicSource.Play ();

		// Solar Flare Variable set
		audioController = GameObject.Find ("MusicSpeedControl").GetComponent<AudioController> (); 
	}


	void FixedUpdate () {
		// Control when to play and pause background music 
		// Interacts with AudioController
		if (audioController.isSoundOn) {
			bgMusicSource.Pause ();
		} else {
			bgMusicSource.UnPause ();
		}
	}
}
