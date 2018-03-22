using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{

	public static UIManager current;

	GameObject currentChar;
	GameObject abilityPanel;


	void Awake(){
		if (current == null){
			current = this;
        }
        else
        {
            Destroy(gameObject);
        }

		abilityPanel = GameObject.Find("AbilityPanel");
	}

	private void Start() {
		if (currentChar != GameManager.current.GetCharacterOnTurn()) {
			currentChar = GameManager.current.GetCharacterOnTurn();
		}
		UpdateUI();
	}

	public void UpdateUI(){
		if (currentChar != GameManager.current.GetCharacterOnTurn()) {
			currentChar = GameManager.current.GetCharacterOnTurn();
		}

		UpdateAbilityPanel();
	}

	void UpdateAbilityPanel() {
		if(currentChar != null) {
			Ability[] abilityList = currentChar.GetComponent<AbilitiesInformation>().abilityList;
			Debug.Log("UIManager > Abilitylist length: " + abilityList.Length);
			if (abilityList.Length > 0) {
				for (int i = 0; i < abilityList.Length; i++) {
					GameObject a = abilityPanel.transform.GetChild(i).gameObject;
					a.GetComponentInChildren<Text>().text = abilityList[i].name;
					string n = abilityList[i].name;
					Debug.Log("UIManager > Adding ability #" + n);
					a.GetComponent<Button>().onClick.AddListener(() => currentChar.GetComponent<AbilitiesInformation>().UseAbility(n));
				}
			}
		}
	}


}
