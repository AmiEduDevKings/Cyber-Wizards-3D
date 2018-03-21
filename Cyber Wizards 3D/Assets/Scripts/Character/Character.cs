using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ScriptableObject {


	

	public Ability[] ablities;

	public int health;
	public int actionPoints;
	public int speed;

	public abstract void Initialize(GameObject character);

}
