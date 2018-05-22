using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityInfo : MonoBehaviour {

	public GameObject abilityInfo;

	public TextMeshProUGUI abilityName;
	public TextMeshProUGUI abilityDescription;

	public void Show() {
		abilityInfo.SetActive(true);
		abilityName.color = AbilityManager.Instance.Hovered.textColor;
		abilityName.text = AbilityManager.Instance.Hovered.name;
		abilityDescription.text = AbilityManager.Instance.Hovered.description;
	}

	public void Hide() {
		abilityInfo.SetActive(false);
	}
}
