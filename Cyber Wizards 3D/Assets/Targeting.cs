using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {

	public LayerMask mask;

	public void GetTargeting() {
		if (Raycaster.Instance.CheckHit(mask)) {
			RaycastHit hit = Raycaster.Instance.GetHit();
			Debug.Log("Targeting > Hitting " + hit.collider.gameObject.name);

			if (Input.GetMouseButtonDown(0) && !GameManager.Instance.casting) {
				AbilityHandler.Instance.CastAbility(hit.collider.gameObject, gameObject);
			}
		}
	}
}
