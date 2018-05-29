using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

	public GameObject abilitybarRef;
	public GameObject actionPointsRef;

	private int buttonsCount;
	// Use this for initialization
	void Start () {
		buttonsCount = abilitybarRef.transform.childCount;
	}

	public void OnTurnMasterChanged() {
		UpdateAbilitybar();
		UpdateStats();
	}

	void UpdateAbilitybar() {
		List<Ability> l = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList;
		for(int i = 0; i < buttonsCount; i++) {
			abilitybarRef.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = l[i].name;
		}
	}

	public void UpdateStats() {
		actionPointsRef.GetComponent<TextMeshProUGUI>().text = "ActionPoints: " + GameManager.Instance.TurnMaster.GetComponent<Stats>().currentActionPoints;
	}
}
