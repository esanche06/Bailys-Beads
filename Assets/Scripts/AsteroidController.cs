using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
	private GameObject target;
	private Animator anim;
	private Vector3 targetPosition, mousePosition;
	private Vector2 targetDirection, startPos, endPos, direction, stop;
	private float touchTimeStart, touchTimeFinish, timeInterval, mousePosX, mousePosY;

	[Range (0.05f, 1f)]
	public float throwForce = 0.3f;
	public GameObject GameController;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetInteger ("asteroidType", Random.Range (1, 4));

		target = GameObject.Find ("Sun");
		targetPosition = target.GetComponent<Transform> ().position - transform.position;
		targetDirection = new Vector2 (targetPosition.x, targetPosition.y);
		stop = new Vector2 (0, 0);

		GameObject GameController = GameObject.Find("GameController");
		float level = GameController.GetComponent<GameController> ().level;
		float mod = (float)((.5 * level * Mathf.Log10 (level)) + 10f);
		GetComponent<Rigidbody2D> ().AddForce (targetDirection * Mathf.Min(mod, 25));
	}

	void Update(){
		//touch screen
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			touchTimeStart = Time.time;
			startPos = Input.GetTouch (0).position;
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (new Vector3(startPos.x, startPos.y, 80f)))) {
				GetComponent<Rigidbody2D> ().velocity = stop;
			}
		}

		//release finger
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (new Vector3(startPos.x, startPos.y, 80f)))) {
				touchTimeFinish = Time.time;

				timeInterval = touchTimeFinish - touchTimeStart;

				endPos = Input.GetTouch (0).position;

				direction = startPos - endPos;

				GetComponent<Rigidbody2D> ().AddForce (-direction / timeInterval * throwForce);
			}
		}
	}


}
