using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Warrior")]
public class Warrior : Character
{
	private CharacterStats characterStats;

	public override void Initialize(GameObject character)
	{
		characterStats = character.GetComponent<CharacterStats>();
		characterStats.health = health;
		characterStats.actionPoints = actionPoints;
		characterStats.speed = speed;

		character.GetComponent<AbilitiesInformation>().abilityList = ablities;
	}
}
