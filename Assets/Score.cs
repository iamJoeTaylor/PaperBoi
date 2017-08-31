using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	private int scoreValue;
	public GameObject scoreboard;
	// Use this for initialization
	void Start () {
		scoreValue = 0;
		setScoreboard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetScore() {
		return scoreValue;
	}
	public void SetScore(int newValue) {
		scoreValue += newValue;
		setScoreboard ();
	}

	void setScoreboard() {
		scoreboard.GetComponent<TextMesh> ().text = scoreValue.ToString();
	}
}
