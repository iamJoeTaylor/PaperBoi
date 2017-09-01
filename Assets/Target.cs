using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public int pointValue;
	public GameObject score;

	private bool triggered = false;
	private Dictionary<int, float> scale = new Dictionary<int, float>();

	// Use this for initialization
	void Start () {
		scale.Add (10, 3);
		scale.Add (30, 2);
		scale.Add (100, 1);

		float x = gameObject.transform.localScale.x;
		float y = gameObject.transform.localScale.y;
		gameObject.transform.localScale = new Vector3(x, y, scale[pointValue]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (triggered == true) return;

		score.GetComponent<Score> ().SetScore (pointValue);
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		Color oldColor = renderer.material.color;
		Color newColor = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f); 
		gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", newColor);
		triggered = true;
	}
}
