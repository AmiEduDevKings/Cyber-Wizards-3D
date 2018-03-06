using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsUI : MonoBehaviour {

	public static StatsUI current;

	public Text ap;
	public Text hp;

	GameObject currentChar;


	void Awake() {
		if (current == null) {
			current = this;
		}
	}

	public void UpdateUI() {
		if (currentChar != TurnManager.current.GetCharacterOnTurn()) {
			currentChar = TurnManager.current.GetCharacterOnTurn();
		}

		ap.text = "AP: " + currentChar.GetComponent<Character>().currentActionPoints;
		hp.text = "HP: " + currentChar.GetComponent<Character>().health;
	}
}
