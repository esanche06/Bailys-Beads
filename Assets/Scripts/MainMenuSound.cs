using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour {
	public AudioSource bgMusicSource;
	public AudioClip bgMusicClip;

	// Use this for initialization
	void Start () {
		// Start Playing Background Music for Game
		bgMusicSource = GetComponent<AudioSource> ();
		bgMusicSource.clip = bgMusicClip;
		bgMusicSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
