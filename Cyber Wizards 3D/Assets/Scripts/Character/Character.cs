using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour {

	public int health;
	public int actionPoints;
	public int currentActionPoints;

    public int damage = 50;
    

	public int speed;

    public void TakeDamage(int amount) {
        health -= amount;
    }

    public void Damage(Character ch)
    {
        ch.TakeDamage(damage);
        Debug.Log("Hitting " + ch.gameObject.name + " for " + damage + " damage.");
    }
}
