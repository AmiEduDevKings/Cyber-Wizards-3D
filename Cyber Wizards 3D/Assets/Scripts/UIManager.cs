using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{

	public static UIManager current;

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
		if (currentChar != GameManager.current.GetCharacterOnTurn()){
			currentChar = GameManager.current.GetCharacterOnTurn();
		}

		ap.GetComponent<Text>().text = "AP: " + currentChar.GetComponent<CharacterStats>().currentActionPoints;
		hp.GetComponent<Text>().text = "HP: " + currentChar.GetComponent<CharacterStats>().health;
	}


}
