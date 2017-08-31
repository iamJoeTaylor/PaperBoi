using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagContents : MonoBehaviour {
	public GameObject head;
	public Vector3 offset;
	public Vector3 newsPaperOffset;

	// Use this for initialization
	void Start () {
		setPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		setPosition ();
	}

	void setPosition() {
		GameObject[] newsPapersInBag = GameObject.FindGameObjectsWithTag("NewsPaperInBag");
		Vector3 newPosition = new Vector3 (
			head.transform.position.x + offset.x,
			offset.y + (head.transform.position.y/2),
			head.transform.position.z + offset.z
		);
		gameObject.transform.position = newPosition;
		foreach (GameObject newsPaperInBag in newsPapersInBag) {
			if (newsPaperInBag.GetComponent<VRTK.VRTK_InteractableObject> ().IsGrabbed() == false) {
				newsPaperInBag.transform.position = newPosition + newsPaperOffset;
			}
		}
	}
}
