using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesInformation : MonoBehaviour {

	public Ability[] abilityList;

	public void UseAbility(int id) {
		Ability ability = GetAbility(id);
		if (ability != null) {
			Debug.Log("AbilitiesInformation > Using ability: " + ability.name);
		}
	}

	public void UseAbility(string name) {
		Ability ability = GetAbility(name);
		if (ability != null) {
			Debug.Log("AbilitiesInformation > Using ability: " + ability.name);
		}
	}

	public Ability GetAbility(int id) {
		for (int i = 0; i < abilityList.Length; i++) {
			if (abilityList[i].id == id) {
				return abilityList[i];
			}
		}

		Debug.Log("AbilitiesInformation > No ability found with id: " + id);
		return null;
	}

	public Ability GetAbility(string name) {
		for (int i = 0; i < abilityList.Length; i++) {
			if (abilityList[i].name == name) {
				return abilityList[i];
			}
		}

		Debug.Log("AbilitiesInformation > No ability found with name: " + name);
		return null;
	}



}
