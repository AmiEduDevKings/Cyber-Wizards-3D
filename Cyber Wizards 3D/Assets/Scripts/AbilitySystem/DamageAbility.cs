using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Ability", menuName = "Ability/Damage", order = 1)]
public class DamageAbility : Ability {

	public int damagePower;


	public override void Print() {
		Debug.Log("Ability > Type: " + GetType() + " Ability: " + name);
	}

	public override void TriggerAbility(GameObject target)
	{
		target.GetComponent<CharacterStats>().TakeDamage(damagePower);
		
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
