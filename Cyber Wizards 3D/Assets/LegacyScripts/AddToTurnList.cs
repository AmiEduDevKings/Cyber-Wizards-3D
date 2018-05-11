using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace legacyScripts
{

	public class AddToTurnList : MonoBehaviour
	{

		public Combat Combat;
		//combat event lista vois olla hyvä
		private void OnEnable()
		{
			Combat.AddToTurnList(gameObject);
		}


		private void OnDisable()
		{
			Combat.RemoveFromTurnList(gameObject);
		}




	}
}
