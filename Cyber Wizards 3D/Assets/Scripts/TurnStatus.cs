using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatus : MonoBehaviour {

    public Turn turn;
    private CharacterStats ch;
    public GameObject cam;
    public GameObject canvas;
    public GameObject circleRadiusGO;

    DrawCircle circleRadius;

	//start nyt on vaan start

	void Start() {
		//GameManager.current.AddToTurnList(gameObject);
		ch = gameObject.GetComponent<CharacterStats>();
        cam = GameObject.Find("Main Camera");
        canvas = transform.Find("CharacterCanvas").gameObject;
        circleRadiusGO = GameObject.Find("CircleRadius");
        circleRadius = circleRadiusGO.GetComponent<DrawCircle>();
    }

	//aloitetaan vuoro
    public void StartTurn() {
        turn = Turn.ON;
        if (gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Movement>().enabled = true;
        }
        //canvas.SetActive(true);
        ch.currentActionPoints = ch.actionPoints;
        Debug.Log(gameObject.name + " turn");
        cam.GetComponent<Follow>().target = gameObject;
        circleRadiusGO.transform.position = transform.position;
        circleRadius.CreatePoints();
    }


	//endataan vuoro
    public void EndTurn() {
        turn = Turn.OFF;
        if (gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Movement>().enabled = false;
        }
        canvas.SetActive(false);
        GameManager.Instance.NextTurn();
    }


	//ajetaan matsin alussa
    public void StartMatch() {
        turn = Turn.OFF;
        if (gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Movement>().enabled = false;
        }
        canvas.SetActive(false);
        ch.currentActionPoints = ch.actionPoints;
    }
}
