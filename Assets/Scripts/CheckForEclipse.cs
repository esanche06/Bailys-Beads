using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEclipse : MonoBehaviour {
	public GameObject Earth;
	public GameObject Moon;
	public float distance = 1;
	public bool isEclipse = false;

	private RaycastHit2D[] results;
	private ContactFilter2D filter;
	private Vector3 dir;

	void Start () {
		results = new RaycastHit2D[3];
		filter = new ContactFilter2D ();
		filter.NoFilter(); //Probably going to actually add filters later but not right now
		distance = Vector3.Distance(transform.position, Earth.transform.position);
	}

	void FixedUpdate () {
		Debug.DrawRay (transform.position, Earth.transform.position, Color.blue, 0f, true);
		if (Physics2D.Raycast (transform.position, Earth.transform.position, filter, results, distance) > 2)
			isEclipse = true;
		else
			isEclipse = false;

	}
}
