using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarFlare : MonoBehaviour {
	private Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		if (Time.time % 5 == 0)
			anim.SetTrigger ("playFlare");
	}
}
