using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDestroyer : MonoBehaviour {
	public GameObject alienSpawner;

	void OnCollisionEnter2D(Collision2D collision){
		if (gameObject.name == "Sun" && collision.gameObject.tag == "Alien") {
			Destroy (collision.gameObject);
			//alienSpawner.GetComponent<AlienSpawnerController> ().collisionSource.Play ();
			alienSpawner.GetComponent<AlienSpawnerController> ().currentAliens--;	
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(gameObject.name == "Background" && collider.gameObject.tag == "Asteroid" && !Input.GetMouseButton(0)){
			Destroy (collider.gameObject);
			alienSpawner.GetComponent<AlienSpawnerController> ().currentAliens--;	
		}
	}
}
