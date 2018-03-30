using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public List<GameObject> turnList;
	
	private CharacterStats ch;
	public GameObject cam;
	public GameObject circleRadiusGO;

	DrawCircle circleRadius;

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
		ch = gameObject.GetComponent<CharacterStats>();
		cam = GameObject.Find("Main Camera");
		circleRadiusGO = GameObject.Find("CircleRadius");
		circleRadius = circleRadiusGO.GetComponent<DrawCircle>();

		index = 0;
		Invoke("StartMatch", 0.1f);
	}

	public GameObject GetCharacterOnTurn() { 
		return turnList[index];
	}

	public void AddToTurnList(GameObject obj) {
		turnList.Add(obj);
	}

	private static int SortBySpeed(GameObject o1, GameObject o2){
		return o1.GetComponent<CharacterStats>().speed.CompareTo(o2.GetComponent<CharacterStats>().speed);
	}

	
	void StartMatch() {
		turnList.Sort(SortBySpeed);
		for (int i = 0; i < turnList.Count; i++) {
			SetMatchStartToCharacter(turnList[i]);
		}
		StartTurn();
		Debug.Log("Match Start");
	}

	

	public void EndTurn() {
		if (turnList[index].CompareTag("Player"))
		{
			turnList[index].GetComponent<Movement>().enabled = false;
		}
		index = (index + 1) % turnList.Count;
		StartTurn();
		UIManager.Instance.UpdateUI();
	}


	void StartTurn() {
		Debug.Log("vuoro indeksissä: " + index + ", " + turnList[index].name);
		
		if (turnList[index].CompareTag("Player"))
		{
			turnList[index].GetComponent<Movement>().enabled = true;
		}
		turnList[index].GetComponent<CharacterStats>().ResetActionPoints();

		Debug.Log(gameObject.name + " turn");
		cam.GetComponent<Follow>().target = turnList[index];
		circleRadiusGO.transform.position = turnList[index].transform.position;
		circleRadius.CreatePoints();
		UIManager.Instance.UpdateUI();
	}


	void SetMatchStartToCharacter(GameObject character) {
		if (character.CompareTag("Player"))
		{
			character.GetComponent<Movement>().enabled = false;
		}
		character.GetComponent<CharacterStats>().ResetActionPoints();
	}
}
