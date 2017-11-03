﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public GameObject Parent;
	public float speed;
	private PlayerEclipseInput sunScript;
	private Vector3 zAxis = new Vector3(0,0,1);

	void FixedUpdate(){
		// Rotation for GameObject if user has successfully achieve eclipse
		sunScript = GameObject.Find ("Sun").GetComponent<PlayerEclipseInput>();

		// Stop the rotation
		if (!sunScript.success) {
			speed = 0;
		}
		transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);
	}


}
