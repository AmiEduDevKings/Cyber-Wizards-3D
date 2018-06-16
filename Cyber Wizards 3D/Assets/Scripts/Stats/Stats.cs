using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour {

	public StatsSO stats;
	public float movementRange = 20f;

    public UnityEvent DeathEvent;

	[HideInInspector]
	public float health;

	[HideInInspector]
	public float speed;
	[HideInInspector]

	public float actionPoints;

	public float currentActionPoints;
	public float currentHealth;

	private void Start()
	{
		stats.Initialize(this);
		currentActionPoints = actionPoints;
		currentHealth = health;
	}

	public float GetMovementRange() {
		return movementRange;
	}

	public void ResetActionPoints()
	{
		currentActionPoints = actionPoints;
	}


	private void Death()
	{
		Debug.Log("Stats: " + name + ": Im Dead");

        DeathEvent.Invoke();
	}


	public void TakeDamage(int amount)
	{
		Debug.Log("CharacterStats: " + name + "Ottaa damagea " + amount);
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Death();
		}
	}
}
