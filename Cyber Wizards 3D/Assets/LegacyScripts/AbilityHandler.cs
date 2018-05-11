﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace legacyScripts
{

	public class AbilityHandler : MonoBehaviour
	{

		public static AbilityHandler Instance;
		public Ability selectedAbility;

		void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		//public void UseAbility(Ability ability) {
		//	if (!GameManager.Instance.casting && !GameManager.Instance.moving) {
		//		currentAbility = ability;
		//		GameManager.Instance.casting = true;
		//		if (currentAbility != null) {
		//			Debug.Log("AbilitiesInformation > Using ability: " + currentAbility.name);
		//			currentAbility.Cast(gameObject);
		//			isTargeting = true;
		//		}
		//	}
		//}

		public void SelectAbility(Ability ability)
		{
			GameManager.Instance.EnableTargeting();
			selectedAbility = ability;
			Debug.Log("AbilityHandler: Selected Ability -> " + ability.name);
		}

		public void CastAbility(GameObject target, GameObject self)
		{
			float dist = Vector3.Distance(target.transform.position, self.transform.position);
			Debug.Log("AbilityHandler: CastAbility - > Ability " + selectedAbility + " distance: " + dist + " and range: " + selectedAbility.range);

			if (!target.GetComponent<Tags>().IsRightTag(selectedAbility))
			{
				Debug.Log("AbilityHandler: CastAbility -> not right tag on selected target");
				return;
			}


			if (!GameManager.Instance.casting && !GameManager.Instance.moving &&
				dist <= selectedAbility.range)
			{
				selectedAbility.Cast(GameManager.Instance.GetCharacterOnTurn(), target);
			}
		}
	}
}
