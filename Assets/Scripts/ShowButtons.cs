using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour {
	private GameController gc;

	void Start () {
		gc = GameObject.Find ("GameController").GetComponent<GameController>();
		for (int i = 0; i < transform.childCount; i++)
			transform.GetChild (i).gameObject.SetActive (false);
	}

	void FixedUpdate () {
		if (gc.gameFailed) {
			for (int i = 0; i < transform.childCount; i++)
				transform.GetChild (i).gameObject.SetActive (true);
			gameObject.GetComponent<CanvasGroup> ().alpha = 1;
		} 
	}
}
