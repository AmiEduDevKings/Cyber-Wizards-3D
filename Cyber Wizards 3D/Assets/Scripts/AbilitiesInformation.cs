using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesInformation : MonoBehaviour {

	public Ability[] abilityList;

    public Ability currentAbility;

	bool isTargeting;
    private void Update()
    {

		//Fiksataan tää myöhemmin. Mut pohja targetoinnille on tässä. 
		if (isTargeting)
		{
			if (Input.GetMouseButton(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					if (hit.collider.gameObject.CompareTag(currentAbility.targetTag))
					{
						Debug.Log("AbilityInformation > Hit target");
						currentAbility.TriggerAbility(hit.collider.gameObject);
						currentAbility.Print();
						isTargeting = false;
					}
				}

			}
		}
	}

    public void UseAbility(int id) {
		currentAbility = GetAbility(id);
		if (currentAbility != null) {
			Debug.Log("AbilitiesInformation > Using ability: " + currentAbility.name);
			StartCoroutine(ExecuteAbility(currentAbility));
			isTargeting = true;
		}
	}

	public void UseAbility(string name) {
		currentAbility = GetAbility(name);
		if (currentAbility != null) {
			Debug.Log("AbilitiesInformation > Using ability: " + currentAbility.name);
			StartCoroutine(ExecuteAbility(currentAbility));
			isTargeting = true;
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


	IEnumerator ExecuteAbility(Ability ability) {
		if(ability.effect1 != null) {
			Instantiate(ability.effect1, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(ability.startUpTime);
		}

		if(ability.effect2 != null) {
			Instantiate(ability.effect2, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
			yield return new WaitForSeconds(ability.duration);
		}

		Debug.Log("AbilitiesInformation > Ability Executed!");
	}
}
