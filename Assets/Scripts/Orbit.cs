using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public GameObject Parent;
	public float speed;

	private float xPos, yPos, distance;
	private SolarFlare solarFlare;
	private int randIndex;
	private int[] posOrNeg;
	private Vector3 zAxis = new Vector3(0,0,1);

	//For Alien Bonus Slow Down
	private AlienCollector bonusAlien;


	void Start(){
		solarFlare = GameObject.Find ("Sun").GetComponent<SolarFlare> (); 

		randIndex = Random.Range (0, 2);
		posOrNeg = new int[] {-1, 1};

		//Debug.Log (gameObject.name + " " + transform.localPosition);

		distance = Vector3.Distance (new Vector3(0, 0, 0), transform.localPosition);

		//Debug.Log (gameObject.name + " " + Parent.transform.localPosition + " " + Parent.transform.position);

		xPos = Random.Range (-distance, distance);
		yPos = (Mathf.Sqrt((Mathf.Pow(distance, 2) - Mathf.Pow((xPos), 2))) * posOrNeg[randIndex]);

		//Debug.Log (gameObject.name + " " + xPos +  " " + yPos);

		transform.localPosition = new Vector3 (xPos, yPos, transform.position.z);

		//For Alien Bonus Slow Down
		bonusAlien = GameObject.FindWithTag ("Alien").GetComponent<AlienCollector> ();
	}

	void FixedUpdate(){
		// Sets the speed for Orbit depended on SolarFlare
		if (solarFlare.flaring) {
			transform.RotateAround (Parent.transform.position, zAxis, solarFlare.flareSpeedRate * speed * Time.deltaTime);
		} else {
			transform.RotateAround (Parent.transform.position, zAxis, speed * Time.deltaTime);
		}

		if (bonusAlien.collected) {
			transform.RotateAround (Parent.transform.position, zAxis, bonusAlien.bonusSpeedRate * speed * Time.deltaTime);
		}
	}

}
