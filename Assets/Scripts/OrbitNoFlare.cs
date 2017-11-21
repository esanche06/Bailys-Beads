using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitNoFlare : MonoBehaviour {
	public GameObject Parent;
	public float speed;

	private float xPos, yPos, distance;
	private int randIndex;
	private int[] posOrNeg;
	private Vector3 zAxis = new Vector3(0,0,1);

	void Start(){
		randIndex = Random.Range (0, 2);
		posOrNeg = new int[] {-1, 1};

		//Debug.Log (gameObject.name + " " + transform.localPosition);

		distance = Vector3.Distance (new Vector3(0, 0, 0), transform.localPosition);

		//Debug.Log (gameObject.name + " " + Parent.transform.localPosition + " " + Parent.transform.position);

		xPos = Random.Range (-distance, distance);
		yPos = (Mathf.Sqrt((Mathf.Pow(distance, 2) - Mathf.Pow((xPos), 2))) * posOrNeg[randIndex]);

		//Debug.Log (gameObject.name + " " + xPos +  " " + yPos);

		transform.localPosition = new Vector3 (xPos, yPos, transform.position.z);
	}

	void FixedUpdate(){
			transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);
	}
}
