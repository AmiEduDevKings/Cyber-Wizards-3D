﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	Image button;

	public Color color;
	public Color hover;
	public Color pressed;

	bool selected = false;

	private void Start() {
		button = GetComponent<Image>();

		Reset();
	}

	public void OnPointerClick(PointerEventData eventData) {
		for (int i = 0; i < transform.parent.childCount; i++) {
			transform.parent.GetChild(i).GetComponent<Image>().color = color;
			transform.parent.GetChild(i).GetComponent<AbilityButton>().selected = false;
		}

		selected = true;
		button.color = pressed;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		if (!selected)
			button.color = hover;
	}

	public void OnPointerExit(PointerEventData eventData) {
		if (!selected)
			button.color = color;
	}

	public void Reset() {
		selected = false;
		button.color = color;
	}

}
