﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public GameObject Parent;
	public float speed;

	private float xPos, yPos, distance, unityDistance;
	private SolarFlare solarFlare;
	private int randIndex;
	private int[] posOrNeg;
	private Vector3 zAxis = new Vector3(0,0,1);

	void Start(){
		solarFlare = GameObject.Find ("Sun").GetComponent<SolarFlare> ();

		randIndex = Random.Range (0, 2);
		posOrNeg = new int[] {-1, 1};

		distance = Vector3.Distance (Parent.transform.position, transform.position);

		xPos = Random.Range (-distance, distance);
		yPos = Mathf.Sqrt((Mathf.Pow(distance, 2) - Mathf.Pow(xPos, 2))) * posOrNeg[randIndex];

		transform.localPosition = new Vector3 (xPos, yPos, transform.position.z);
	}

	void FixedUpdate(){
		if (solarFlare.flaring)
			transform.RotateAround (Parent.transform.position, zAxis, 2 * speed * Time.deltaTime);
		else
			transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);
	}
}
