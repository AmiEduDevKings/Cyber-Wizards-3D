using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClass {

	private Vector3 input;

	public TargetClass() {
		
	}

	public Vector3 GetVector(Vector3 input) {


		Ray ray = Camera.main.ScreenPointToRay(input);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.point;
	}

	public string GetTag(Vector3 input) {

		Ray ray = Camera.main.ScreenPointToRay(input);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.collider.tag;
	}

	public RaycastHit GetraycastHit(Vector3 input){

		Ray ray = Camera.main.ScreenPointToRay(input);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)){
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit;
	}

	

	

	
	
}
