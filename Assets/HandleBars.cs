using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBars : MonoBehaviour {

	public GameObject HandleBarsGO;
	// public GameObject BrakeGO;

	private Quaternion target;

	// Use this for initialization
	void Start () {
		target = HandleBarsGO.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		HandleBarsGO.transform.localRotation = Quaternion.Slerp (HandleBarsGO.transform.localRotation, target, Time.deltaTime * 1.2f);
	}

	public void turnBarsLeft(float angle) {
		target = Quaternion.Euler (0, angle, 90);
	}

	public void brakePercent(float brakePercent) {
		// BrakeGO.transform.rotation = Quaternion.Euler (0, brakePercent * 30, 0);
	}
}