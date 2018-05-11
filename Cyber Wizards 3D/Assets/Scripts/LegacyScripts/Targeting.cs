using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	public class Targeting : MonoBehaviour
	{

		public Raycaster caster;
		public LayerMask mask;

		public void GetTargeting()
		{
			if (caster.CheckHit(mask))
			{
				RaycastHit hit = caster.GetHit();
				Debug.Log("Targeting > Hitting " + hit.collider.gameObject.name);

				if (Input.GetMouseButtonDown(0) && !GameManager.Instance.casting)
				{
					AbilityHandler.Instance.CastAbility(hit.collider.gameObject, gameObject);
				}
			}
		}
	}
}
