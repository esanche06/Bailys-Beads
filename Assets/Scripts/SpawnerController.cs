using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	public int maxAsteroids = 5;
	public GameObject asteroid;
	public int asteroidSpeed;

	private int currentAsteroids;
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
			GameObject asteroidClone;
			asteroidClone = Instantiate (asteroid, transform.position, transform.rotation);

			wait = true;
			count = 0;
			currentAsteroids++;
		}

		if (wait) {
			if (count >= 5f)
				wait = false;
			
			else
				count += Time.deltaTime;
		}
	}
}
