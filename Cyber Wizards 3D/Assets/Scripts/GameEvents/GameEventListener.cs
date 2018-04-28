using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{

	public GameEvent ListenedEvent;

	public UnityEvent OnEvent;

	public void OnEventRaised() {
		OnEvent.Invoke();
	}

	private void OnEnable()
	{
		ListenedEvent.AddListener(this);
	}

	private void OnDisable()
	{
		ListenedEvent.RemoveListener(this);
	}
}
