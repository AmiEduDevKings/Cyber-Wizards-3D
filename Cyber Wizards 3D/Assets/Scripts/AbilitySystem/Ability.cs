﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Ability : ScriptableObject
{

	public string targetTag = "Player";
	public int id = -1;
	public Sprite icon;
	public new string name = "new ability";

	public ParticleSystem effect1;
	public ParticleSystem effect2;
	public ParticleSystem effect3;

	public float startUpTime;
	public float duration;
	public float endTime;

	public float velocity;
	public float range;

	public abstract void Print();
	public abstract void TriggerAbility(GameObject target);

	public void Cast(GameObject target)
	{
		target.GetComponent<MonoBehaviour>().StartCoroutine(ExecuteAbility(target));
	}

	public IEnumerator ExecuteAbility(GameObject target)
	{
		GameManager.Instance.casting = true;
		if (effect1 != null)
		{
			Instantiate(effect1, target.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(startUpTime);
		}

		if (effect2 != null)
		{
			Instantiate(effect2, target.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
			yield return new WaitForSeconds(duration);
		}

		if (effect3 != null)
		{
			Instantiate(effect3, target.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
			yield return new WaitForSeconds(endTime);
		}

		Debug.Log("AbilitiesInformation > Ability Executed!");
		GameManager.Instance.casting = false;
	}
}
