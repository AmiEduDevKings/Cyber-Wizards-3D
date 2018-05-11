using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

	public GameObject abilitybarRef;

	private int buttonsCount;
	// Use this for initialization
	void Start () {
		buttonsCount = abilitybarRef.transform.childCount;
		Debug.Log(buttonsCount);
	}

	public void OnTurnMasterChanged() {
		UpdateUI();
	}

	public void UpdateUI() {
		UpdateAbilitybar();
	}

	void UpdateAbilitybar() {
		List<Ability> l = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList;
		for(int i = 0; i < buttonsCount; i++) {
			abilitybarRef.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = l[i].name;
		}
	}
}
