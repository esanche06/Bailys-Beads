using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	public GameObject asteroid;
	public int asteroidSpeed;
	public int currentAsteroids;
	public int maxAsteroids = 10;
	public AudioSource collisionSource;
	public AudioClip collisionClip;

	private bool wait;
	private float count, waitTime;

	void Start(){
		currentAsteroids = 0;
		wait = true;
		count = 0;
		waitTime = Random.Range (1f, 5f);
		collisionSource = GetComponent<AudioSource> ();
		collisionSource.clip = collisionClip;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (currentAsteroids < maxAsteroids && !wait) {
			Instantiate (asteroid, transform.position, transform.rotation);

			wait = true;
			count = 0;
			currentAsteroids++;
			waitTime = Random.Range (1f, 5f);
		}

		if (wait) {
			if (count >= waitTime)
				wait = false;
			
			else
				count += Time.deltaTime;
		}
	}
}
