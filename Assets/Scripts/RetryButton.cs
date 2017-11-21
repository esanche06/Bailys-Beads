using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name); //.buildindex?
	}
}
