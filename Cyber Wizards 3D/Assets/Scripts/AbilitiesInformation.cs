using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesInformation : MonoBehaviour {

	public Ability[] abilityList;

	public Ability currentAbility;

	bool isTargeting;
	private void Update() {
		//Fiksataan tää myöhemmin. Mut pohja targetoinnille on tässä. 
		if (isTargeting) {
			if (Input.GetMouseButton(0)) {
				if (Raycaster.Instance.CheckHit()) {
					if (Raycaster.Instance.GetObject().CompareTag(currentAbility.targetTag)) {
						Debug.Log("AbilityInformation > Hit target");
						currentAbility.TriggerAbility(Raycaster.Instance.GetHit().collider.gameObject);
						currentAbility.Print();
						isTargeting = false;
					}
				}
			}
		}
	}

	public void UseAbility(Ability ability) {
		if (!GameManager.Instance.casting && !GameManager.Instance.moving) {
			currentAbility = ability;
			GameManager.Instance.casting = true;
			if (currentAbility != null) {
				Debug.Log("AbilitiesInformation > Using ability: " + currentAbility.name);
				currentAbility.Cast(gameObject);
				isTargeting = true;
			}
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


	//IEnumerator ExecuteAbility(Ability ability) {
	//	if (ability.effect1 != null) {
	//		Instantiate(ability.effect1, transform.position, Quaternion.identity);
	//		yield return new WaitForSeconds(ability.startUpTime);
	//	}

	//	if (ability.effect2 != null) {
	//		Instantiate(ability.effect2, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
	//		yield return new WaitForSeconds(ability.duration);
	//	}

	//	if (ability.effect3 != null) {
	//		Instantiate(ability.effect3, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
	//		yield return new WaitForSeconds(ability.endTime);
	//	}

	//	Debug.Log("AbilitiesInformation > Ability Executed!");
	//	GameManager.Instance.casting = false;
	//}
}
