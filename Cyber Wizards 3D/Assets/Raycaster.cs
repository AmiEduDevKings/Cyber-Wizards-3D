using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour {

	private Ray ray;
	private RaycastHit hit;

	public static Raycaster Instance;
	
	private void Awake() {
		if(Instance != null && Instance != this) {
			Destroy(gameObject);
		}

		Instance = this;
	}

	public bool CheckHit(LayerMask mask) {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		return Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
	}

	public bool CheckHit() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		return Physics.Raycast(ray, out hit, Mathf.Infinity);
	}

	public RaycastHit GetHit() {
		return hit;
	}

	public GameObject GetObject() {
		return hit.collider.gameObject;
	}
}
