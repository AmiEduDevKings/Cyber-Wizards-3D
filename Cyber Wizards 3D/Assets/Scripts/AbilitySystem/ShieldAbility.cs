using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shield Ability", menuName = "Ability/Shield", order = 2)]

public class ShieldAbility : Ability {

	public int shieldPower;

	public override void Print() {
		Debug.Log("Ability > Type: " + GetType() + " Ability: " + name);
	}

	public override void TriggerAbility(GameObject target)
	{
		target.GetComponent<CharacterStats>().TakeDamage(shieldPower);
	}
}
