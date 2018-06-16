using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	public List<GameObject> turnList = new List<GameObject>();

	int index = 0;

	

	public void AddToList(GameObject character) {
		if (!turnList.Contains(character)) {
			turnList.Add(character);
			return;
		}

		Debug.LogError("Character " + character.name + " already exists in turnlist");
	}

	public void RemoveFromList(GameObject character) {
		if (turnList.Contains(character)) {
			turnList.Remove(character);
			return;
		}

		Debug.LogError("Character " + character.name + " doesn't exist in the turnlist.");
	}

    public void StartMatch() {
        turnList[index].GetComponent<TurnStatus>().StartTurn();
    }

	public void OnTurnChanged() {
		index = (index + 1) % turnList.Count;
        turnList[index].GetComponent<TurnStatus>().StartTurn();
    }
}
