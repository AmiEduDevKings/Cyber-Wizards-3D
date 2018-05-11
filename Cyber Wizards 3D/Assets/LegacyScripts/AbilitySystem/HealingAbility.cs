using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace legacyScripts
{
	[CreateAssetMenu(fileName = "New Healing Ability", menuName = "Ability/Healing", order = 3)]

	public class HealingAbility : Ability
	{

		public int healingPower;

		public override void Print()
		{
			Debug.Log("Ability > Type: " + GetType() + " Ability: " + name);
		}

		public override void TriggerAbility(GameObject target)
		{
			target.GetComponent<CharacterStats>().TakeHealing(healingPower);
			UIManager.Instance.DamagePopup(target, healingPower, textColor);
		}



		public override IEnumerator ExecuteAbility(GameObject caster, GameObject target)
		{


			if (effect1 != null)
			{
				Instantiate(effect1, caster.transform.position, Quaternion.identity);
				yield return new WaitForSeconds(startUpTime);
			}

			if (effect2 != null)
			{
				Instantiate(effect2, target.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
				yield return new WaitForSeconds(duration);
			}

			if (effect3 != null)
			{
				Instantiate(effect3, target.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
				TriggerAbility(target);
				yield return new WaitForSeconds(endTime);
			}



			Debug.Log("AbilitiesInformation > Ability Executed!");
			GameManager.Instance.casting = false;
		}

		public override void Cast(GameObject caster, GameObject self)
		{
			self.GetComponent<MonoBehaviour>().StartCoroutine(ExecuteAbility(caster, self));
			GameManager.Instance.casting = true;
		}



	}
}
