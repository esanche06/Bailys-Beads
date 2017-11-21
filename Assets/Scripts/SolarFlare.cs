using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarFlare : MonoBehaviour {
	public bool flaring;

	private float timeSinceFlare, timeTillNextFlare;
	private Animator anim;

	void Start(){
		timeSinceFlare = 0f;
		anim = GetComponent<Animator> ();
		timeTillNextFlare = Random.Range (10f, 15f);

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
			timeTillNextFlare = Random.Range (10f, 15f);
		}

		if (flaring)
			timeSinceFlare += Time.deltaTime;
	}
}
