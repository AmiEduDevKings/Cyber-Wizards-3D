using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Ability", menuName = "Ability/Healing", order = 3)]

public class HealingAbility : Ability {

	public int healingPower;
	public AbilityType type = AbilityType.HEALING;

	public void Print() {
		Debug.Log("Ability > Type: " + type.ToString() + " Ability: " + name);
	}
}
