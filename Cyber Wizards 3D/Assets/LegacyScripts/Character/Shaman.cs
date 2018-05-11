using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	[CreateAssetMenu(menuName = "Characters/Shaman")]
	public class Shaman : Character
	{

		private CharacterStats characterStats;

		public override void Initialize(GameObject character)
		{
			characterStats = character.GetComponent<CharacterStats>();
			characterStats.health = health;
			characterStats.actionPoints = actionPoints;
			characterStats.speed = speed;

			characterStats.abilities = abilities;
		}

	}
}
