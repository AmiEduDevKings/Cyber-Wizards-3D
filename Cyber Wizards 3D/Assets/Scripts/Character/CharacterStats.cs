using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStats : MonoBehaviour {
	[HideInInspector]
	public int health;
	[HideInInspector]
	public int actionPoints;

	public int currentActionPoints;
	public int currentHealth;

	[HideInInspector]
	public int speed;

	public Character character;

	private void Start()
	{
		character.Initialize(gameObject);
		currentHealth = health;
	}

	public void TakeDamage(int amount) {
		Debug.Log("CharacterStats : " + name + "Ottaa damagea " + amount);
		currentHealth -= amount;
		if (currentHealth <= 0) {
			Death();
		}
    }

	private void Death()
	{
		Debug.Log("Im Dead");
	}
}
