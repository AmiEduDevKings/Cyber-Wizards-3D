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

	
}
