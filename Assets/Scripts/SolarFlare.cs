using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarFlare : MonoBehaviour {
	public bool flaring;
	public AudioSource solarFlareSource;
	public AudioClip solarFlareClip;
	public float flareSpeedRate;
	public GameObject GameController;

	private int level;
	private float maxWait, minWait;
	private float timeSinceFlare, timeTillNextFlare;
	private Animator anim;
	private float[] values = {0.5f, 1.25f, 1.5f, 1.75f, 2.0f, 2.25f};

	void Start(){
		level = GameController.GetComponent<GameController> ().level;
		maxWait = ((-1 / 10) * level) + 15;
		minWait = maxWait - 5;
		timeSinceFlare = 0f;
		anim = GetComponent<Animator> ();
		timeTillNextFlare = Random.Range (minWait, maxWait);
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

			level = GameController.GetComponent<GameController> ().level;
			maxWait = ((-1f / 10f) * level) + 15;
			minWait = maxWait - 5;
			timeTillNextFlare = Random.Range (Mathf.Max(5f, minWait), Mathf.Max(10f, maxWait));
			//Debug.Log(level + " " + minWait + " " + maxWait);
		}

		if (flaring)
			timeSinceFlare += Time.deltaTime;
	}

	void getFlareSpeedRate() {
		// Determine the speed rate based on a random range
		flareSpeedRate = values [Random.Range (0, values.Length)];
		//Debug.Log (flareSpeedRate);
	}
}
