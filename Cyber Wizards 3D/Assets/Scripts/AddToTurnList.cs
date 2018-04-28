using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToTurnList : MonoBehaviour {

	public Combat Combat;

	private void OnEnable()
	{
		Combat.AddToTurnList(gameObject);
	}


	private void OnDisable()
	{
		Combat.AddToTurnList(gameObject);
	}




}

