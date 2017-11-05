using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public GameObject Parent;
	public float speed;

	private PlayerEclipseInput sunScript;
	private float initialSpeed;
	private Vector3 zAxis = new Vector3(0,0,1);

	void Start(){
		sunScript = GameObject.Find ("Sun").GetComponent<PlayerEclipseInput>();
		initialSpeed = speed;
	}

	void FixedUpdate(){
		// Stop the rotation
		if (sunScript.failure) {
			speed = 0;
		}

		transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);
	}


}
