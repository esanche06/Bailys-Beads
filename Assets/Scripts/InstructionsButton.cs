using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour {
	public void OnClick(){
		SceneManager.LoadSceneAsync ("Instructions"); //.buildindex?
	}
}
