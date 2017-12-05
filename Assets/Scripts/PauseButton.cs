using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {
	public Canvas PauseCanvas;
	public GameObject GameController;

	public void FixedUpdate(){
		if (GameController.GetComponent<GameController> ().gameFailed)
			gameObject.SetActive (false);
	}

	public void OnClick(){
		Time.timeScale = 0;
		PauseCanvas.GetComponent<OnPause> ().pausePressed = true;
	}
}
