using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareController : MonoBehaviour {
	public GameObject Parent, Earth;
	public float speed;

	private bool animationStarted, newPos;
	private Vector3 zAxis;
	private float animationTime;
	private Animator anim;

	void Start(){
		zAxis = new Vector3(0,0,1);

		anim = GetComponent<Animator> ();
		animationTime = 0f;
		animationStarted = false;

		newPos = true;
	}

	void FixedUpdate(){
		if (newPos) {
			moveSolarFlare ();
			newPos = false;
		}

		transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);

		if (Time.time % 5 == 0)
			anim.SetTrigger ("playFlare");
	}


	void moveSolarFlare(){
		//Moves the solar flare object so the animation and rotation can be lined up with the Earth
		float myX = 0f, myY = 0f;
		float earthX = Earth.transform.position.x, earthY = Earth.transform.position.y;
		float myAngle = 0f;

		if (earthY >= 0) {
			myAngle = Mathf.Acos (earthX / 20f) * Mathf.Rad2Deg;
		} else if (earthX <= 0) {
			myAngle = 180 + (-1 * (Mathf.Asin (earthY / 20f) * Mathf.Rad2Deg));
		} else if (earthX > 0) {
			myAngle = 360 + (Mathf.Asin (earthY / 20f) * Mathf.Rad2Deg);
		}

		transform.position = new Vector3 (10 * Mathf.Cos (myAngle * Mathf.Deg2Rad), 10 * Mathf.Sin (myAngle * Mathf.Deg2Rad), transform.position.z);
		transform.eulerAngles = new Vector3 (transform.rotation.x, transform.rotation.y, myAngle);
	}
}
