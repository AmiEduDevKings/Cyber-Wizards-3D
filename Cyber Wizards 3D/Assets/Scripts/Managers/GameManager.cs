﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

	public bool m_DebugLogging;

	public GameEvent OnTurnMasterChanged;
	public GameObject TurnMaster { get; set; }

	public bool Moving { get; set; }
	public bool Casting { get; set; }

	public void SetTurnMaster(GameObject character) {
		if(m_DebugLogging)
		Log("TurnMaster Changed!");

		TurnMaster = character;

		OnTurnMasterChanged.RaiseAll();
	}

	public void Log(string str) {
		Debug.Log("GameManager-> " + str);
	}
}
