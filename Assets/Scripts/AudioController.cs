using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	public AudioSource AudSource;
	public AudioClip[] AudClip;
	public bool isSoundOn = false;

	private SolarFlare solarFlare;


	void Start () {
		// Get Sourcces and Components
		AudSource = GetComponent<AudioSource> ();
		solarFlare = GameObject.Find ("Sun").GetComponent<SolarFlare> (); 
	}
	

	void Update () {
		// Play and Pause Speed up and Slow down sound effect based on solar flare speed rate
		if (solarFlare.flaring) {
			if (solarFlare.flareSpeedRate < 1 && !isSoundOn) {
				PlaySound (0);
			} else if (solarFlare.flareSpeedRate > 1 && !isSoundOn) {
				PlaySound (1);
			}
		} else {
			isSoundOn = false;
			AudSource.Pause ();
		}
	}


	void PlaySound (int clipNum) {
		// Play Sound effect once
		isSoundOn = true;
		AudSource.clip = AudClip [clipNum];
		AudSource.Play ();
	}
}
