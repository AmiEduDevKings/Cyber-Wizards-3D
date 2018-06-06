using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

	public bool m_DebugLogging;

	public GameEvent OnTurnMasterChanged;
    public GameEvent OnAiTurn;
	public GameObject TurnMaster { get; set; }
    public GameObject CurrentAi { get; set; }

	public bool Moving { get; set; }
	public bool Casting { get; set; }
    public bool AiTurn { get; set; }

	public void SetTurnMaster(GameObject character) {
		if(m_DebugLogging)
		Log("TurnMaster Changed!");

        if (character.GetComponent<GiantAI>())
        {
            Debug.Log("GameManager -> AI Turn!");
            CurrentAi = character;
            AiTurn = true;
            OnAiTurn.RaiseAll();
            return;
        }

        AiTurn = false;
        TurnMaster = character;
        OnTurnMasterChanged.RaiseAll();
	}

	public void Log(string str) {
		Debug.Log("GameManager-> " + str);
	}
}
