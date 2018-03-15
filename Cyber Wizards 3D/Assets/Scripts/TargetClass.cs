using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClass {

	private GameObject targetPoint;
	private Transform input;
	private List<string> tagit; 

	public TargetClass(Transform input, GameObject targetPoint){
		this.input = input;
		this.targetPoint = targetPoint;
	}


	private Vector3 CalculateTarget(){

		Ray ray = Camera.main.ScreenPointToRay(input.position);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)){
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.point;
	}
	
	private string GetHitTag() {

		Ray ray = Camera.main.ScreenPointToRay(input.position);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100)){
			Debug.DrawLine(ray.origin, hit.point);
		}

		return hit.collider.tag;
	}
	

	//hakee targetin
	public Vector3 GetDestination(){
		return CalculateTarget();
	}

	//hakee tagin
	public string GetTag() {
		return GetHitTag();
	}
	
}
