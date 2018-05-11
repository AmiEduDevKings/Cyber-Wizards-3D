using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Legacy/TagObject")]
public class TagObject : ScriptableObject {
	
	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
			return false;

		TagObject tag = obj as TagObject;
		
		return tag.GetHashCode() == GetHashCode();
	}

	public override int GetHashCode()
	{
		return name.GetHashCode();
	}

	
}
