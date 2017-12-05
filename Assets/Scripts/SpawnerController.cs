using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	public GameObject asteroid;
	public GameObject GameController;
	public int asteroidSpeed;
	public int currentAsteroids;
	public int maxAsteroids = 10;
	public AudioSource collisionSource;
	public AudioClip collisionClip;

	private bool wait;
	private float count, waitTime, maxWaitTime;
	private int level;

	void Start(){
		level = GameController.GetComponent<GameController> ().level;
		maxWaitTime = ((-1 / 10) * level) + 5f;
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
			level = GameController.GetComponent<GameController> ().level;
			waitTime = Random.Range (1f, Mathf.Max(1f, maxWaitTime));
			maxWaitTime = ((-1f / 10f) * level) + 5f;
		}

		if (wait) {
			if (count >= waitTime)
				wait = false;
			
			else
				count += Time.deltaTime;
		}
	}
}
