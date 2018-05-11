using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {

	bool targetingEnabled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetingEnabled) {
			
		}
	}

	public void OnAbilitySelected() {
		targetingEnabled = true;
	}
}
