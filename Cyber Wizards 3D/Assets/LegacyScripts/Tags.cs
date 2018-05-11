using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	public class Tags : MonoBehaviour
	{

		public TagObject[] tags;

		public bool IsRightTag(Ability ability)
		{
			foreach (var item in tags)
			{
				if (item.Equals(ability.targetTag))
				{
					return true;
				}
			}
			return false;
		}
	}
}
