using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClass {

	private Transform input;

	public TargetClass(Transform input) {
		this.input = input;
	}


	private Vector3 CalculateTarget() {

		Ray ray = Camera.main.ScreenPointToRay(input.position);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.point;
	}

	private string GetHitTag() {

		Ray ray = Camera.main.ScreenPointToRay(input.position);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.collider.tag;
	}

	private RaycastHit GetHit(){

		Ray ray = Camera.main.ScreenPointToRay(input.position);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)){
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit;
	}

	//hakee targetin
	public Vector3 GetDestination() {
		return CalculateTarget();
	}

	//hakee tagin
	public string GetTag() {
		return GetHitTag();
	}

	public RaycastHit GetRayCastHit() {
		return GetHit();
	}

	
	
}
