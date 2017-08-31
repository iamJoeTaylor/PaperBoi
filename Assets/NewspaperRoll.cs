using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperRoll : MonoBehaviour {
	public int myLayer = 8; // define the layer in the prefab script (8 to 31)

	// Use this for initialization
	void Start () {
		// and ignore collisions between objects in it:
		Physics.IgnoreLayerCollision(myLayer, myLayer, true);
	}

	// Update is called once per frame
	void Update () {

	}
}
