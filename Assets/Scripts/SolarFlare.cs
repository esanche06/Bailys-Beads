using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarFlare : MonoBehaviour {
	public bool flaring;

	private float timeSinceFlare;
	private Animator anim;

	void Start(){
		timeSinceFlare = 0f;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		if (timeSinceFlare > 5f) {
			timeSinceFlare = 0f;
			flaring = false;
		}

		if (Time.time % 10 == 0 && Time.time != 0) {
			flaring = true;
			anim.Play ("SunFlare");
		}

		if (flaring)
			timeSinceFlare += Time.deltaTime;
	}
}
