using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType {
	HEALING,
	DAMAGE,
	SHIELD
}

public abstract class Ability : ScriptableObject {


	public int id = -1;
	public Sprite icon;
	public new string name = "new ability";

	ParticleSystem effect1;
	ParticleSystem effect2;
	ParticleSystem effect3;

	public float velocity;
	public float range;

}
