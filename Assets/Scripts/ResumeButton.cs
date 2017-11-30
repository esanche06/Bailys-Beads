using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour {
	public Canvas PauseCanvas;

	public void OnClick(){
		Time.timeScale = 1;
		PauseCanvas.GetComponent<OnPause> ().resumePressed = true;
	}
}
