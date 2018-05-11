using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Legacy/Game Event")]
public class GameEvent : ScriptableObject {

	List<GameEventListener> activeListeners = new List<GameEventListener>();

	public void AddListener(GameEventListener gameEventListener)
	{
		activeListeners.Add(gameEventListener);
	}

	public void RemoveListener(GameEventListener gameEventListener) {
		activeListeners.Remove(gameEventListener);
	}

	public void Raise() {
		for (var i = activeListeners.Count - 1; i >= 0; i--)
		{
			activeListeners[i].OnEventRaised();
		}
	}


}
