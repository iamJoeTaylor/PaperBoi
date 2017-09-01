using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZone : MonoBehaviour {
	public int pointValue;
	public GameObject score;

//	private bool triggered = false;
//	private Dictionary<int, float> scale = new Dictionary<int, int>();

	// Use this for initialization
	void Start () {
//		scale.Add (10, 3);
//		scale.Add (30, 2);
//		scale.Add (100, 1);
//
//		gameObject.transform.localScale.z = scale [pointValue];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		// if (triggered == true) return;

		// score.GetComponent<Score> ().SetScore (pointValue);
//		gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
//		triggered = true;
	}
}