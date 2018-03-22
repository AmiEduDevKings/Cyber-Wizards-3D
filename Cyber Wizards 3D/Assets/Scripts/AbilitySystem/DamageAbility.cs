using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/New DamageAbility")]
public class DamageAbility : Ability {

	public int damage = 50;
	public float velocity = 50;
	public float range = 50;

	public override void TriggerAbility(GameObject target){

		Debug.Log(this.name + ": TriggerAbility");
	}
}
