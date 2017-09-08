using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour {
	public float speed;
	public GameObject steeringScript;
	public WheelCollider FrontWheelCol;
	public WheelCollider BackWheelColRight;
	public WheelCollider BackWheelColLeft;
	public GameObject CenterOfMass;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().centerOfMass = CenterOfMass.transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		BackWheelColRight.motorTorque = speed;
		BackWheelColLeft.motorTorque = speed;

	}

	public void steerBikeLeft(float angle) {
		FrontWheelCol.steerAngle = angle;
	}

	public void brakePercent(float brakePercent) {
		if (brakePercent >= .9)
			brakePercent = 1;
		BackWheelColLeft.brakeTorque = brakePercent * speed;
		BackWheelColRight.brakeTorque = brakePercent * speed;
	}
}
