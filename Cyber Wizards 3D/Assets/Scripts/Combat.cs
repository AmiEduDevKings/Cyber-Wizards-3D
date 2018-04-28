using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat")]
public class Combat : ScriptableObject {

	List<GameObject> turnList = new List<GameObject>();



	public void AddToTurnList(GameObject charater) {
		turnList.Add(charater);
	}

	public void RemoveFromTurnList(GameObject character){
		turnList.Remove(character);
	}

	public void StartMatch()
	{
		turnList.Sort(SortBySpeed);
		Debug.Log("Match Start");

	}

	private static int SortBySpeed(GameObject o1, GameObject o2)
	{
		return o1.GetComponent<CharacterStats>().speed.CompareTo(o2.GetComponent<CharacterStats>().speed);
	}
}
