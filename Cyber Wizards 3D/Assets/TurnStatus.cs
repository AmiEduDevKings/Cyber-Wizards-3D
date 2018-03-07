﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatus : MonoBehaviour {

	public Turn turn;
	private Character ch;
	public GameObject cam;

	void Start(){
		TurnManager.current.AddToTurnList(gameObject);
		ch = gameObject.GetComponent<Character>();
		cam = GameObject.Find("Main Camera");
	}

	public void StartTurn() {
		turn = Turn.ON;
		if (gameObject.CompareTag("Player")) {
			gameObject.GetComponent<PlayerInput>().enabled = true;
            gameObject.GetComponentInChildren<DrawCircle>().CreatePoints();
        }
		StatsUI.current.UpdateUI();
		ch.currentActionPoints = ch.actionPoints;
		Debug.Log(gameObject.name + " turn");
		cam.GetComponent<Follow>().target = gameObject;
	}

	public void EndTurn() {
		turn = Turn.OFF;
		if (gameObject.CompareTag("Player")){
			gameObject.GetComponent<PlayerInput>().enabled = false;
            gameObject.GetComponent<PlayerInput>().lr.positionCount = 0;
            gameObject.GetComponentInChildren<DrawCircle>().RemovePoints();
        }
		TurnManager.current.NextTurn();
	}

	public void StartMatch() {
		turn = Turn.OFF;
		if (gameObject.CompareTag("Player")){
			gameObject.GetComponent<PlayerInput>().enabled = false;
            gameObject.GetComponent<PlayerInput>().lr.positionCount = 0;
            gameObject.GetComponentInChildren<DrawCircle>().RemovePoints();
        }
		StatsUI.current.UpdateUI();
		ch.currentActionPoints = ch.actionPoints;
	}
}
