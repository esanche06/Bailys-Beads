using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour {
	private GameController gc;

	void Start(){
		gc = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Asteroid"){
			gc.gameFailed = true;
		}
	}

}
