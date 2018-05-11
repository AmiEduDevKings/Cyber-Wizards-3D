using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StatsSO")]
public class StatsSO : ScriptableObject {

	public int health;
	public int actionPoints;
	public int speed;
	public int movementRange;

	private Stats characterStats;

	public void Initialize(Stats stats)
	{
		characterStats = stats;
		characterStats.health = health;
		characterStats.actionPoints = actionPoints;
		characterStats.speed = speed;
		characterStats.movementRange = movementRange;
	}
}
