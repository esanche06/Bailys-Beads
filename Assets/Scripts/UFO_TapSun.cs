using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_TapSun : MonoBehaviour {

	public Vector3 startPos = new Vector3(-65f, -42.08f, 0);
	public Vector3 endPos = new Vector3(0f, -42.08f, 0);
	private float speed = 10f;
	float startTime;
	float journeyLength;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector3.Distance (startPos, endPos);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startPos, endPos, fracJourney);
	}
}
