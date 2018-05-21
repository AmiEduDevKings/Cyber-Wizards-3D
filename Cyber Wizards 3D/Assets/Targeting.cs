using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {

	public LayerMask mask;
	bool targetingEnabled = false;

	// Update is called once per frame
	void Update() {
		if (targetingEnabled) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask)) {
				if (hit.collider) {
					if (Input.GetMouseButtonDown(0) && !GameManager.Instance.Casting) {

						GameObject caster = GameManager.Instance.TurnMaster;
						GameObject target = hit.collider.gameObject;
						Ability ability = AbilityManager.Instance.Ability;

						if(Vector3.Distance(caster.transform.position, target.transform.position) < ability.range) {
							ability.Cast(caster, target);
						} else {
							Debug.Log("Targeting -> Out of ability range");
						}
					}
				}
			}
		}
	}

	public void OnAbilitySelected() {
		targetingEnabled = true;
	}

	public void OnTurnChanged() {
		targetingEnabled = false;
	}
}
