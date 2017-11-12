using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour {
	public GameObject asteroidSpawner;

	void OnCollisionEnter2D(Collision2D collision){
		if (gameObject.name == "Sun" && collision.gameObject.tag == "Asteroid") {
			Destroy (collision.gameObject);
			asteroidSpawner.GetComponent<SpawnerController> ().currentAsteroids--;	
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(gameObject.name == "Background" && collider.gameObject.tag == "Asteroid" && !Input.GetMouseButton(0)){
			Destroy (collider.gameObject);
			asteroidSpawner.GetComponent<SpawnerController> ().currentAsteroids--;	
		}
	}
}
