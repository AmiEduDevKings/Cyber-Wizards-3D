using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Ability", menuName = "Ability/Healing", order = 3)]

public class HealingAbility : Ability {

	public int healingPower;

	public override void Print() {
		Debug.Log("Ability > Type: " + GetType() + " Ability: " + name);
	}

	public override void TriggerAbility(GameObject target)
	{
		target.GetComponent<CharacterStats>().TakeDamage(healingPower);
		
	}
}
