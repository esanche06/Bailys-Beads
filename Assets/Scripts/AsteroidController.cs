using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
	private GameObject target;
	private Animator anim;
	private Vector3 targetPosition;
	private Vector2 targetDirection;
	private bool pushed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetInteger ("asteroidType", Random.Range (1, 4));

		target = GameObject.Find ("Sun");

		targetPosition = target.GetComponent<Transform> ().position - transform.position;
		targetDirection = new Vector2 (targetPosition.x, targetPosition.y);

		pushed = false;
	}
		
	void FixedUpdate(){
		if (!pushed) {
			GetComponent<Rigidbody2D> ().AddForce (targetDirection * 10);
			Debug.Log (targetDirection);
			pushed = true;
		}
		//GetComponent<Rigidbody2D> ().AddForce (-transform.up*10);
	}
}
