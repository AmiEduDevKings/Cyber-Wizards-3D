using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClass {

	private Vector3 input;

	public TargetClass() {
		
	}



	private Vector3 CalculateTarget(Vector3 input) {


		Ray ray = Camera.main.ScreenPointToRay(input);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.point;
	}

	private string GetHitTag(Vector3 input) {

		Ray ray = Camera.main.ScreenPointToRay(input);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.collider.tag;
	}

	private RaycastHit GetHit(Vector3 input){

		Ray ray = Camera.main.ScreenPointToRay(input);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)){
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit;
	}

	//hakee targetin
	public Vector3 GetDestination(Vector3 input) {
		return CalculateTarget(input);
	}

	//hakee tagin
	public string GetTag(Vector3 input) {
		return GetHitTag(input);
	}

	public RaycastHit GetRayCastHit(Vector3 input) {
		return GetHit(input);
	}

	
	
}
