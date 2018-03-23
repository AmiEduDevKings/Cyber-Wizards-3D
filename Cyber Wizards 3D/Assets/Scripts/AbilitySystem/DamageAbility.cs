using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Ability", menuName = "Ability/Damage", order = 1)]
public class DamageAbility : Ability {

	public int damagePower;
	public AbilityType type = AbilityType.DAMAGE;

	public void Print() {
		Debug.Log("Ability > Type: " + type.ToString() + " Ability: " + name);
	}
}
