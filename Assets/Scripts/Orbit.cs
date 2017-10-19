using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public float alpha = 0f;
	public float tilt = 45f;
	public float speed = 1F;
	public Vector3 orbitAround = new Vector3(0f,0f,0f);
	public float orbitWidth = 10f;
	public float orbitLength = 5f;

	private Vector3 currPos;
	private Vector3 nextPos;
	private float startTime;
	private float journeyLength;

	void Start () {
		//InvokeRepeating ("Orbit", 0, .07f);
		startTime = Time.time;
		journeyLength = Vector3.Distance(currPos, nextPos);
		updateValues();
	}

	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(currPos, nextPos, fracJourney);
		updateValues ();

		print ("Distance covered: " + distCovered + " Fraction of journey: " + fracJourney);

	}



	float MCos(float val){
		return Mathf.Cos(Mathf.Deg2Rad * val);
	}

	float MSin(float val){
		return Mathf.Sin(Mathf.Deg2Rad * val);
	}

	Vector3 NextOrbitPos(){
		
		 Vector3 OrbitPos = new Vector3 (
			0f + (orbitWidth * MCos(alpha) * MCos(tilt)) - ( orbitLength * MSin(alpha) * MSin(tilt)) + orbitAround.x, //Add to position we want to orbit around? (Makes center)
			0 + orbitAround.y,
			0f + (orbitWidth * MCos(alpha) * MSin(tilt)) + ( orbitLength * MSin(alpha) * MCos(tilt)) + orbitAround.z);
		alpha += 5f;
		return OrbitPos;
	}

	void updateValues(){
		currPos = transform.position;
		nextPos = NextOrbitPos ();
	}
}

/*public class ExampleClass : MonoBehaviour {
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	void Update() {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
	}
}*/
