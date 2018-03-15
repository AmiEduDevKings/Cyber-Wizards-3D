using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatus : MonoBehaviour {

    public Turn turn;
    private Character ch;
    public GameObject cam;
    public GameObject canvas;
    public GameObject circleRadiusGO;

    DrawCircle circleRadius;

    void Start() {
        TurnManager.current.AddToTurnList(gameObject);
        ch = gameObject.GetComponent<Character>();
        cam = GameObject.Find("Main Camera");
        canvas = transform.Find("CharacterCanvas").gameObject;
        circleRadiusGO = GameObject.Find("CircleRadius");
        circleRadius = circleRadiusGO.GetComponent<DrawCircle>();
    }

    public void StartTurn() {
        turn = Turn.ON;
        if (gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Movement>().enabled = true;
        }
        circleRadiusGO.transform.position = transform.position;
        circleRadius.CreatePoints();
        //canvas.SetActive(true);
        StatsUI.current.UpdateUI();
        ch.currentActionPoints = ch.actionPoints;
        Debug.Log(gameObject.name + " turn");
        cam.GetComponent<Follow>().target = gameObject;
    }

    public void EndTurn() {
        turn = Turn.OFF;
        if (gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Movement>().enabled = false;
        }
        canvas.SetActive(false);
        TurnManager.current.NextTurn();
    }

    public void StartMatch() {
        turn = Turn.OFF;
        if (gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Movement>().enabled = false;
        }
        canvas.SetActive(false);

        StatsUI.current.UpdateUI();
        ch.currentActionPoints = ch.actionPoints;
    }
}
