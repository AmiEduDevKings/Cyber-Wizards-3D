using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/New DamageAbility")]
public abstract class Ability : ScriptableObject {

	public string targetTag = "Player";
	public int id = -1;
	public Sprite icon;
	public new string name = "new ability";

	ParticleSystem effect1;
	ParticleSystem effect2;
	ParticleSystem effect3;

	public abstract void TriggerAbility(GameObject target);
}
