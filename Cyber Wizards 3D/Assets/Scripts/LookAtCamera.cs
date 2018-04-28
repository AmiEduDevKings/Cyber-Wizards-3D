using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	public float life;

	// Use this for initialization
	void Start () {
		if (life > 0f) {
			Invoke("InvokeDestroy", life);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
	}

	void InvokeDestroy() {
		Destroy(gameObject);
	}
}
