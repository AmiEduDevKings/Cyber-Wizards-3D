using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour {

	public int health;
	public int actionPoints;
	public int currentActionPoints;

	public int speed;

    public void TakeDamage(int amount) {
        health -= amount;
    }
}
