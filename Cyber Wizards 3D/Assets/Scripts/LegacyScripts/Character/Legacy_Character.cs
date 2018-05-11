using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace legacyScripts
{
	public abstract class Character : ScriptableObject
	{
		
		public Ability[] abilities;

		public int health;
		public int actionPoints;
		public int speed;

		public abstract void Initialize(GameObject character);

	}
}
