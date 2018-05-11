using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	[CreateAssetMenu(menuName = "LegacyScriptableObjects/Combat")]
	public class Combat : ScriptableObject
	{
		//jono vois toimia
		List<GameObject> turnList = new List<GameObject>();

		int index = 0;

		public void AddToTurnList(GameObject charater)
		{
			turnList.Add(charater);
			Debug.Log(charater.name + " lisätty");
		}

		public void RemoveFromTurnList(GameObject character)
		{
			turnList.Remove(character);
		}

		public void StartMatch()
		{
			//turnList.Sort(SortBySpeed);
			Debug.Log("Match Start");
			index = 0;

			turnList[index].GetComponent<CombatMovement>().canMove = true;
		}

		public void EndTurn()
		{
			turnList[index].GetComponent<CombatMovement>().canMove = false;
			index = (index + 1) % turnList.Count;
			turnList[index].GetComponent<CombatMovement>().canMove = true;

		}

		private static int SortBySpeed(GameObject o1, GameObject o2)
		{
			return o1.GetComponent<CharacterStats>().speed.CompareTo(o2.GetComponent<CharacterStats>().speed);
		}
	}
}