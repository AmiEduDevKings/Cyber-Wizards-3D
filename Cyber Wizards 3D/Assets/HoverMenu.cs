using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMenu : MonoBehaviour {

	// Update is called once per frame
	void Update() {
		Vector3 mousep = Input.mousePosition;

		transform.position = mousep;
	}
}
