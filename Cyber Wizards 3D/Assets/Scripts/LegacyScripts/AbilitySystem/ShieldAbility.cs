using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	[CreateAssetMenu(fileName = "New Shield Ability", menuName = "Ability/Shield", order = 2)]

	public class ShieldAbility : Ability
	{

		public int shieldPower;

		public override void Print()
		{
			Debug.Log("Ability > Type: " + GetType() + " Ability: " + name);
		}

		public override void TriggerAbility(GameObject target)
		{
			target.GetComponent<CharacterStats>().MakeShield(shieldPower);
		}



		//public override IEnumerator ExecuteAbilaity(GameObject self)
		//{

		//	if (effect1 != null)
		//	{
		//		Instantiate(effect1, self.transform.position, Quaternion.identity);
		//		yield return new WaitForSeconds(startUpTime);
		//	}

		//	if (effect2 != null)
		//	{
		//		Instantiate(effect2, self.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
		//		yield return new WaitForSeconds(duration);
		//	}

		//	if (effect3 != null)
		//	{
		//		Instantiate(effect3, self.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
		//		yield return new WaitForSeconds(endTime);
		//	}

		//	Debug.Log("AbilitiesInformation > Ability Executed!");
		//	GameManager.Instance.casting = false;
		//}

		//public override void Cast(GameObject self)
		//{
		//	self.GetComponent<MonoBehaviour>().StartCoroutine(ExecuteAbilaity(self));
		//}
	}
}
