using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {
	private GameObject target;
	private Vector3 targetPosition, mousePosition;
	private Vector2 targetDirection, startPos, endPos, direction, stop;
	private float touchTimeStart, touchTimeFinish, timeInterval, mousePosX, mousePosY;

	[Range (0.05f, 1f)]
	public float throwForce = 0.2f;

	void Start () {
			if (transform.position.x < 0) {
			target = GameObject.Find ("RightAlienTarget");
			targetPosition = target.GetComponent<Transform> ().position - transform.position;
			targetDirection = new Vector2 (targetPosition.x, targetPosition.y);
			stop = new Vector2 (0, 0);

			GetComponent<Rigidbody2D> ().AddForce (targetDirection * 4);
		}
		else {
			target = GameObject.Find ("LeftAlienTarget");
			targetPosition = target.GetComponent<Transform> ().position - transform.position;
			targetDirection = new Vector2 (targetPosition.x, targetPosition.y);
			stop = new Vector2 (0, 0);

			GetComponent<Rigidbody2D> ().AddForce (targetDirection * 4);
		}

	}
		


}
