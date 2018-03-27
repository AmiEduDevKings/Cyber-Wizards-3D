using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public List<GameObject> turnList;

	public bool moving = false;
	public bool casting = false;

	private int index;

	void Awake() {
		if (Instance == null)
		{
			Instance = this;
		}
		else {
			Destroy(gameObject);	
		}
	}

	void Start(){
		index = 0;
		Invoke("StartMatch", 0.1f);
	}

	public void AddToTurnList(GameObject obj) {
		turnList.Add(obj);
	}

	private static int SortBySpeed(GameObject o1, GameObject o2){
		return o1.GetComponent<CharacterStats>().speed.CompareTo(o2.GetComponent<CharacterStats>().speed);
	}

	public void SortTurnList() {
		turnList.Sort(SortBySpeed);
	}

	public void NextTurn() {
		index = (index + 1) % turnList.Count;
		turnList[index].GetComponent<TurnStatus>().StartTurn();
		Debug.Log("Vuoro indeksissä: " + index);
	}



	void StartMatch() {
		for (int i = 0; i < turnList.Count; i++) {
			turnList[i].GetComponent<TurnStatus>().StartMatch();
		}
		turnList[index].GetComponent<TurnStatus>().StartTurn();
		Debug.Log("Match Start");
	}

	public GameObject GetCharacterOnTurn() {
		return turnList[index];
	}

	public void EndTurn() {
		turnList[index].GetComponent<TurnStatus>().EndTurn();
		UIManager.Instance.UpdateUI();
	}
}
