using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	[HideInInspector]
	public int index;

	[HideInInspector]
	public bool Selected { get; set; }

	Abilitybar abilitybar;

	private void Start() {
		abilitybar = GetComponentInParent<Abilitybar>();
	}

	public void OnPointerClick(PointerEventData eventData) {
		abilitybar.OnClick(index);
	}

	public void OnPointerEnter(PointerEventData eventData) {
		abilitybar.OnAbilityEnter(index);
	}

	public void OnPointerExit(PointerEventData eventData) {
		abilitybar.AbilityExit(index);
	}
}
