using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldspaceCursor : MonoBehaviour {

	private MeshRenderer r;

	private void Start() {
		r = GetComponent<MeshRenderer>();
	}

	private void Update() {
		r.enabled = !EventSystem.current.IsPointerOverGameObject();
	}
}
