using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnerController : MonoBehaviour {
	public GameObject alien;
	public int alienSpeed;
	public int currentAliens;
	public int maxAliens = 5;
	//public AudioSource collisionSource;
	//public AudioClip collisionClip;

	private bool wait;
	private float count, waitTime;

	void Start(){
		currentAliens = 0;
		wait = true;
		count = 0;
		waitTime = Random.Range (1f, 5f);
		//collisionSource = GetComponent<AudioSource> ();
		//collisionSource.clip = collisionClip;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (currentAliens < maxAliens && !wait) {
			Instantiate (alien, transform.position, transform.rotation);

			wait = true;
			count = 0;
			currentAliens++;
			waitTime = Random.Range (5f, 8f);
		}

		if (wait) {
			if (count >= waitTime)
				wait = false;

			else
				count += Time.deltaTime;
		}
	}
}
