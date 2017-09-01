using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagContents : MonoBehaviour {
	public GameObject head;
	public Vector3 offset;
	public Vector3 newsPaperOffset;

	private Vector3 headStart;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (headStart == null) {
			print (head.transform.position.x);
			headStart = head.transform.localPosition;
		}
		setPosition ();
	}

	void setPosition() {
		GameObject[] newsPapersInBag = GameObject.FindGameObjectsWithTag("NewsPaperInBag");
		Vector3 newPosition = new Vector3 (
			headStart.x + offset.x,
			offset.y + (head.transform.localPosition.y/2),
			headStart.z + offset.z
		);
		gameObject.transform.localPosition = newPosition;
		foreach (GameObject newsPaperInBag in newsPapersInBag) {
			if (newsPaperInBag.GetComponent<VRTK.VRTK_InteractableObject> ().IsGrabbed() == false) {
				newsPaperInBag.transform.localPosition = gameObject.transform.position + newsPaperOffset;
			}
		}
	}
}
