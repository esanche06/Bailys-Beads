using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public GameObject Parent;
	public float speed;

	private Vector3 zAxis = new Vector3(0,0,1);

	void FixedUpdate(){
		transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);
	}


}
