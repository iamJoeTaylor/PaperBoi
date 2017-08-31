using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZone : MonoBehaviour {
	public int pointValue;
	public GameObject score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		score.GetComponent<Score> ().SetScore (pointValue);
		Debug.Log ("on trigger enter");
	}
}
