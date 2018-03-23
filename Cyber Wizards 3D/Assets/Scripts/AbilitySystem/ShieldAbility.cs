using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shield Ability", menuName = "Ability/Shield", order = 2)]

public class ShieldAbility : Ability {

	public int shieldPower;
	public AbilityType type = AbilityType.SHIELD;

	public void Print() {
		Debug.Log("Ability > Type: " + type.ToString() + " Ability: " + name);
	}
}
