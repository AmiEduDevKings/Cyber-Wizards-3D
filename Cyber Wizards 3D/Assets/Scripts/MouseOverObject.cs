using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObject : MonoBehaviour {

	public Color color;
	private Color oldColor;

	private void OnMouseOver()
	{
		oldColor = gameObject.GetComponent<Renderer>().material.color;
		gameObject.GetComponent<Renderer>().material.color = color;
	}

	private void OnMouseExit()
	{
		gameObject.GetComponent<Renderer>().material.color = oldColor;
	}
}
