using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarFlare : MonoBehaviour {
	public bool flaring;
	public AudioSource solarFlareSource;
	public AudioClip solarFlareClip;
	public float flareSpeedRate;

	private float timeSinceFlare, timeTillNextFlare;
	private Animator anim;
	private float[] values = {0.5f, 1.25f, 1.5f, 1.75f, 2.0f, 2.25f};

	void Start(){
		timeSinceFlare = 0f;
		anim = GetComponent<Animator> ();
		timeTillNextFlare = Random.Range (10f, 15f);
		solarFlareSource = GetComponent<AudioSource> ();
		solarFlareSource.clip = solarFlareClip;
	}

	void FixedUpdate(){
		if(!flaring)
			timeTillNextFlare -= Time.deltaTime;
		
		if (timeSinceFlare > 5f) {
			timeSinceFlare = 0f;
			flaring = false;
		}

		if (timeTillNextFlare <= 0 && Time.time != 0) {
			flaring = true;
			anim.Play ("SunFlare");
			getFlareSpeedRate ();
			solarFlareSource.Play ();
			timeTillNextFlare = Random.Range (10f, 15f);
		}

		if (flaring)
			timeSinceFlare += Time.deltaTime;
	}

	void getFlareSpeedRate() {
		// Determine the speed rate based on a random range
		flareSpeedRate = values [Random.Range (0, values.Length)];
		Debug.Log (flareSpeedRate);
	}
}
