using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour {
	public GameObject Bike;
	public GameObject HandleBars;
	public GameObject ForkTree;

	public GameObject  leftHand;


	private Vector3 neutralLocalPosition;
	private float adjacentSide;
	private float oppositeSide;
	private bool shouldUpdateSteering = false;

	// Use this for initialization
	void Start () {
		leftHand.GetComponent<VRTK.VRTK_ControllerEvents> ().ButtonOnePressed += new VRTK.ControllerInteractionEventHandler (LeftButtonOnePressed);
		leftHand.GetComponent<VRTK.VRTK_ControllerEvents> ().ButtonOneReleased += new VRTK.ControllerInteractionEventHandler (LeftButtonOneReleased);
		leftHand.GetComponent<VRTK.VRTK_ControllerEvents>().TriggerAxisChanged += new VRTK.ControllerInteractionEventHandler(LeftTriggerAxisChanged);
		setNeutralLocalPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 controllerLocalPosition = getControllerLocalPosition ();
		oppositeSide = Vector3.Distance (controllerLocalPosition, neutralLocalPosition);

		float rawAngle = Mathf.Atan (oppositeSide / adjacentSide) * (180 / Mathf.PI);

		// float dampenedRawAngle = rawAngle;
		float angleLeft = (controllerLocalPosition - neutralLocalPosition).z >= 0
			? rawAngle
			: rawAngle * -1;

		if (!shouldUpdateSteering) {
			angleLeft = 0;
		}

		Bike.GetComponent<Bike> ().steerBikeLeft (angleLeft);
		HandleBars.GetComponent<HandleBars> ().turnBarsLeft (angleLeft);

	}

	Vector3 getControllerLocalPosition() {
		Vector3 LeftControllerPos = gameObject.transform.InverseTransformPoint (leftHand.transform.position);
		return new Vector3 (LeftControllerPos.x, neutralLocalPosition.y, LeftControllerPos.z);
	}

	void setNeutralLocalPosition() {
		neutralLocalPosition = getControllerLocalPosition ();
		adjacentSide = Vector3.Distance (ForkTree.transform.position, leftHand.transform.position);
	}

	private void LeftButtonOnePressed(object sender, VRTK.ControllerInteractionEventArgs e) {
		shouldUpdateSteering = false;
	}	

	private void LeftButtonOneReleased(object sender, VRTK.ControllerInteractionEventArgs e) {
		shouldUpdateSteering = true;
		setNeutralLocalPosition ();
	}

	private void LeftTriggerAxisChanged(object sender, VRTK.ControllerInteractionEventArgs e) {
		float brakePercentage = e.buttonPressure < .1 ?
			0 : e.buttonPressure;

		Bike.GetComponent<Bike> ().brakePercent (brakePercentage);
		HandleBars.GetComponent<HandleBars> ().brakePercent (brakePercentage);
	}
}
