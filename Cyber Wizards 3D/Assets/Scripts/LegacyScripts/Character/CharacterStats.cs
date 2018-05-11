using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace legacyScripts
{
	public class CharacterStats : MonoBehaviour
	{
		[HideInInspector]
		public int health;
		[HideInInspector]
		public int actionPoints;

		public Ability[] abilities;

		public int currentActionPoints;
		public int currentHealth;
		public int currentShield;

		[HideInInspector]
		public int speed;

		public Character character;

		private void Start()
		{
			character.Initialize(gameObject);
			currentHealth = health;
			currentShield = 0;
		}

		public void ResetActionPoints()
		{
			currentActionPoints = actionPoints;
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

		public void TakeHealing(int amount)
		{
			Debug.Log("CharacterStats: " + name + "ottaa healia " + amount);
			if (currentHealth + amount <= health)
			{
				currentHealth += amount;
			}
			else if (currentHealth + amount > health)
			{
				currentHealth = health;
			}
		}

		public void MakeShield(int amount)
		{
			currentShield += amount;
		}

		private void Death()
		{
			Debug.Log("Im Dead");
			GameManager.Instance.RemoveFromTurnList(gameObject);
			gameObject.SetActive(false);
		}


	}
}