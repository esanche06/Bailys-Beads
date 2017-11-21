using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour {
	public void OnClick(){
		SceneManager.LoadSceneAsync ("MainMenu"); //.buildindex?
	}
}
