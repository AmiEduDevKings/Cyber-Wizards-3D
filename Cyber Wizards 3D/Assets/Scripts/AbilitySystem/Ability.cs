using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Ability : ScriptableObject {

	public string targetTag = "Player";
	public int id = -1;
	public Sprite icon;
	public new string name = "new ability";

	public ParticleSystem effect1;
	public ParticleSystem effect2;
	public ParticleSystem effect3;

	public float velocity;
	public float range;

	public abstract void Print();
	public abstract void TriggerAbility(GameObject target);

}
