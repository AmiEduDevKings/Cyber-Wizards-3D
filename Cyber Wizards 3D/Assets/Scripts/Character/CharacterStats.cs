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
	
	[HideInInspector]
	public int speed;

	public Character character;

	private void Start()
	{
		character.Initialize(gameObject);	
	}

	public void TakeDamage(int amount) {
        health -= amount;
		if (health <= 0) {
			Death();
		}
    }

	private void Death()
	{
		Debug.Log("Im Dead");
	}
}
