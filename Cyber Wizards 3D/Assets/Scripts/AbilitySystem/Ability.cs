using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : ScriptableObject {

	public Sprite uiImage;
	public string aName = "new ability";
	public int Damage;

	public abstract void Initialize(GameObject obj);
	public abstract void TriggerAbility();
}
