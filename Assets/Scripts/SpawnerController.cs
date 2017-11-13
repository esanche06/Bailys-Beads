using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	public GameObject asteroid;
	public int asteroidSpeed;
	public int currentAsteroids;
	public int maxAsteroids = 10;

	private bool wait;
	private float count;

	void Start(){
		currentAsteroids = 0;
		wait = false;
		count = 0;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (currentAsteroids < maxAsteroids && !wait) {
			Instantiate (asteroid, transform.position, transform.rotation);

			wait = true;
			count = 0;
			currentAsteroids++;
		}

		if (wait) {
			if (count >= 2.5f)
				wait = false;
			
			else
				count += Time.deltaTime;
		}
	}
}
