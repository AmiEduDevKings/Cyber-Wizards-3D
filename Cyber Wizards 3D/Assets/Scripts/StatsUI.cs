using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour{

	public static StatsUI current;

	public GameObject ap;
	public GameObject hp;

	GameObject currentChar;


	void Awake(){
		if (current == null){
			current = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}

	void Start(){
		ap = gameObject.transform.Find("AP").gameObject;
		hp = gameObject.transform.Find("HP").gameObject;
	}

	public void UpdateUI(){
		if (currentChar != TurnManager.current.GetCharacterOnTurn()){
			currentChar = TurnManager.current.GetCharacterOnTurn();
		}

		ap.GetComponent<Text>().text = "AP: " + currentChar.GetComponent<Character>().currentActionPoints;
		hp.GetComponent<Text>().text = "HP: " + currentChar.GetComponent<Character>().health;
	}
}
