using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour {
	public GameObject newspaper;
	public GameObject spentPapers;


	private Vector3 spawnSpot;
	public Vector3 spawnOffset;

	void OnTriggerExit(Collider obj) {
	}

	void createNewNewspaper() {
		spawnSpot = gameObject.transform.position + spawnOffset;
		GameObject newNewspaper = Instantiate (newspaper);
		newNewspaper.transform.position = spawnSpot;
		newNewspaper.tag = "NewsPaperInBag";

		newNewspaper.GetComponent<VRTK.VRTK_InteractableObject>().InteractableObjectGrabbed += new VRTK.InteractableObjectEventHandler(ObjectGrabbed);
		newNewspaper.GetComponent<VRTK.VRTK_InteractableObject>().InteractableObjectUngrabbed += new VRTK.InteractableObjectEventHandler(ObjectUngrabbed);
	}

	private void ObjectGrabbed(object sender, VRTK.InteractableObjectEventArgs e) {
		VRTK.VRTK_InteractableObject vrtkObject = sender as VRTK.VRTK_InteractableObject;
		GameObject _newsPaper = vrtkObject.gameObject;
		_newsPaper.GetComponent<Rigidbody> ().useGravity = true;
		_newsPaper.GetComponent<NewspaperRoll> ().tag = "NewsPaper";
	}		

	private void ObjectUngrabbed(object sender, VRTK.InteractableObjectEventArgs e) {
		createNewNewspaper ();
	}

	// Use this for initialization
	void Start () {
		createNewNewspaper ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
