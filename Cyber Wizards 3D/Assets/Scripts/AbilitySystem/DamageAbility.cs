using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Damage")]
public class DamageAbility : Ability
{


	public int damagePower;
	Vector3 vel = Vector3.zero;

	ParticleSystem p1, p2, p3;

	public override void Print()
	{
		Debug.Log("Ability > Type: " + GetType() + " Ability: " + name);
	}

	public override void TriggerAbility(GameObject target)
	{
		target.GetComponent<Stats>().TakeDamage(damagePower);
	//	UIManager.Instance.DamagePopup(target, damagePower, textColor);
	}


	public override IEnumerator ExecuteAbility(GameObject caster, GameObject target)
	{
		if (effect1 != null)
		{
			p1 = Instantiate(effect1, caster.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(startUpTime);
		}

		if (effect2 != null)
		{
			p2 = Instantiate(effect2, caster.transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

			while (Vector3.Distance(p2.transform.position, target.transform.position) > 0.1f)
			{
				p2.gameObject.transform.LookAt(target.transform);
				p2.transform.position = Vector3.MoveTowards(p2.transform.position, target.transform.position, velocity * Time.deltaTime);
				//p2.transform.position = Vector3.SmoothDamp(p2.transform.position, target.transform.position, ref vel, 0.1f, velocity);
				yield return new WaitForFixedUpdate();
			}

			Destroy(p2.gameObject);
		}

		if (effect3 != null)
		{
			p3 = Instantiate(effect3, target.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
			yield return new WaitForSeconds(endTime);
		}
		TriggerAbility(target);
		Debug.Log("AbilitiesInformation > Ability Executed!");
		GameManager.Instance.Casting = false;
	}

	public override void Cast(GameObject caster, GameObject target)
	{
		GameManager.Instance.Casting = true;
		target.GetComponent<MonoBehaviour>().StartCoroutine(ExecuteAbility(caster, target));
	}
}
