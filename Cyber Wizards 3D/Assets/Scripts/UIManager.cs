using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

	public static UIManager Instance;

	GameObject currentChar;
	GameObject abilityPanel;


	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}

		abilityPanel = GameObject.Find("AbilityPanel");
	}

	private void Start() {
		if (currentChar != GameManager.Instance.GetCharacterOnTurn()) {
			currentChar = GameManager.Instance.GetCharacterOnTurn();
		}
		UpdateUI();
	}

	public void UpdateUI() {
		if (currentChar != GameManager.Instance.GetCharacterOnTurn()) {
			currentChar = GameManager.Instance.GetCharacterOnTurn();
		}

		UpdateAbilityPanel();
	}

	void UpdateAbilityPanel() {
		if (currentChar != null) {
			Ability[] abilityList = currentChar.GetComponent<CharacterStats>().abilities;
			//Debug.Log("UIManager > Abilitylist length: " + abilityList.Length);
			if (abilityList.Length > 0) {
				for (int i = 0; i < abilityList.Length; i++) {
					GameObject a = abilityPanel.transform.GetChild(i).gameObject;
					a.GetComponentInChildren<TextMeshProUGUI>().text = abilityList[i].name;
					string n = abilityList[i].name;
					//Debug.Log("UIManager > Adding ability #" + n);
					Ability ability = abilityList[i];
					if (abilityList != null) {
						a.GetComponent<Button>().onClick.AddListener(() => AbilityHandler.Instance.SelectAbility(ability));
					}
				}
			}
		}
	}
}
