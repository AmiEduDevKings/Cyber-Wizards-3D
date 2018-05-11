using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldspaceCursor : MonoBehaviour {

	private MeshRenderer r;
	private bool visible = true;

	private void Start() {
		r = GetComponent<MeshRenderer>();
	}

	private void Update() {
		if (visible) {
			r.enabled = !EventSystem.current.IsPointerOverGameObject();
		}
	}

	public void OnAbilitySelected() {
		r.enabled = false;
		visible = false;
	}

	public void OnTurnChanged() {
		r.enabled = true;
		visible = true;
	}
}
